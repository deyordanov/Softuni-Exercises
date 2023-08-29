namespace MiniORM
{
    using System.Collections;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Reflection;
    using Exceptions;
    using Microsoft.Data.SqlClient;

    public class DbContext
    {
        private readonly DatabaseConnection connection;
        private readonly Dictionary<Type, PropertyInfo> dbSetProperties;
        //Dictionary<Employee, PropertyInfo(DbSet<Employee>)>
        internal static readonly Type[] AllowedSqlTypes =
        {
            typeof(string),
            typeof(int),
            typeof(uint),
            typeof(long),
            typeof(ulong),
            typeof(decimal),
            typeof(bool),
            typeof(DateTime)
        };

        protected DbContext(string connectionString)
        {
            this.connection = new DatabaseConnection(connectionString);
            this.dbSetProperties = DiscoverDbSets();
            using (new ConnectionManager(this.connection))
            {
                InitializeDbSets();
            }

            MapAllRelations();
        }

        public void SaveChanges()
        {
            object?[] dbSets = this.dbSetProperties
                .Select(kvp => kvp.Value.GetValue(this))
                .ToArray();

            foreach (IEnumerable<object?> dbSet in dbSets)
            {
                object?[] invalidEntities = dbSet
                    .Where(entity => !IsObjectValid(entity))
                    .ToArray();

                if (invalidEntities.Any())
                {
                    throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidEntitiesException,
                        invalidEntities.Length, dbSet.GetType().Name));
                }
            }


            using (new ConnectionManager(this.connection))
            {
                using (SqlTransaction transaction = this.connection.StartTransaction())
                {
                    foreach (IEnumerable<object?> dbSet in dbSets)
                    {
                        //We take the generic argument of the current set ->
                        //DbSet<Employee> => generic argument = Employee
                        //We take only the first one since we are 100% sure that only one
                        //generic argument is provided.
                        Type dbSetType = dbSet
                            .GetType()
                            .GetGenericArguments()
                            .First();
                        //We create a run-time, generic instance of the 'Persist' method, why ?
                        //We are not sure what type will be given as input, this way we can make sure that
                        //all the correct information the method needs is provided.
                        MethodInfo persistMethod = typeof(DbContext)
                            .GetMethod("Persist", BindingFlags.Instance | BindingFlags.NonPublic)
                            .MakeGenericMethod(dbSetType);

                        //We dynamically invoke the generic method, create earlier. If any exceptions are thrown,
                        //then we rollback the transaction and do not commit the changes that have been made.
                        try
                        {
                            persistMethod.Invoke(this, new object[] { dbSet });
                        }
                        catch (TargetInvocationException tie)
                        {
                            transaction.Rollback();
                            throw tie.InnerException;
                        }
                        catch (InvalidOperationException)
                        {
                            transaction.Rollback();
                            throw;
                        }
                        catch (SqlException)
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }

                    transaction.Commit();
                }
            }
        }

        private void Persist<TEntity>(DbSet<TEntity> dbSet)
            where TEntity : class, new()
        {
            string tableName = GetTableName(typeof(TEntity));
            string[] columns = this.connection.FetchColumnNames(tableName).ToArray();
            //If any rows(objects / instances of a class) have been added, we update the table
            if (dbSet.ChangeTracker.Added.Any())
            {
                this.connection.InsertEntities(dbSet.ChangeTracker.Added, tableName, columns);
            }

            //If any already-existing entities have been modified, we update the table
            TEntity[] modifiedEntities = dbSet.ChangeTracker.GetModifiedEntities(dbSet).ToArray();
            if (modifiedEntities.Any())
            {
                this.connection.UpdateEntities(modifiedEntities, tableName, columns);
            }

            //If any rows have been removed, we update the table.
            if (dbSet.ChangeTracker.Removed.Any())
            {
                this.connection.DeleteEntities(dbSet.ChangeTracker.Removed, tableName, columns);
            }
        }

        private void InitializeDbSets()
        {
            foreach (KeyValuePair<Type, PropertyInfo> dbSet in this.dbSetProperties)
            {
                Type dbSetType = dbSet.Key;
                PropertyInfo dbSetProperty = dbSet.Value;

                MethodInfo populateDbSetGeneric = typeof(DbContext)
                    .GetMethod("PopulateDbSet", BindingFlags.Instance | BindingFlags.NonPublic)
                    .MakeGenericMethod(dbSetType);

                populateDbSetGeneric.Invoke(this, new object[] { dbSetProperty });
            }
        }

        private void PopulateDbSet<TEntity>(PropertyInfo dbSet)
            where TEntity : class, new()
        {
            IEnumerable<TEntity> entities = LoadTableEntities<TEntity>();
            DbSet<TEntity> dbSetInstance = new DbSet<TEntity>(entities);
            ReflectionHelper.ReplaceBackingField(this, dbSet.Name, dbSetInstance);
        }

        private void MapAllRelations()
        {
            foreach (KeyValuePair<Type, PropertyInfo> dbSetProperty in this.dbSetProperties)
            {
                Type dbSetType = dbSetProperty.Key;
                MethodInfo mapRelationsGeneric = typeof(DbContext)
                    .GetMethod("MapRelations", BindingFlags.Instance | BindingFlags.NonPublic)
                    .MakeGenericMethod(dbSetType);
                //Getting the instance of this entity from the current class
                object? dbSet = dbSetProperty.Value.GetValue(this);
                mapRelationsGeneric.Invoke(this, new[] { dbSet });
            }
        }

        private void MapRelations<TEntity>(DbSet<TEntity> dbSet)
            where TEntity : class, new()
        {
            //TEntity = Department.
            Type entityType = typeof(TEntity);

            //We map all navigation properties.
            MapNavigationProperties(dbSet);

            foreach (PropertyInfo property in entityType.GetProperties())
            {
                Console.WriteLine(property.Name);
                Console.WriteLine(property.PropertyType);
                if (property.PropertyType.IsGenericType)
                {
                    Console.WriteLine(property.PropertyType.Name.Substring(0, property.PropertyType.Name.IndexOf('`')));
                    Console.WriteLine(typeof(ICollection).Name);
                }
                Console.WriteLine("---------------");
            }

            //Getting all the collections, whose generic type is ICollection ->
            //Meaning: One department can have more than one Employee => inside the Department we have
            //ICollection<Employee>, that is what we are looking for.

            // PropertyInfo[] collections = entityType
            //     .GetProperties()
            //     .Where(pi =>
            //         pi.PropertyType.IsGenericType &&
            //         pi.PropertyType.Name.Substring(0, pi.PropertyType.Name.IndexOf('`')) == typeof(ICollection).Name)
            //     .ToArray();

            var collections = entityType
                .GetProperties()
                .Where(pi =>
                    pi.PropertyType.IsGenericType &&
                    pi.PropertyType.GetGenericTypeDefinition() == typeof(ICollection<>))
                .ToArray();

            foreach (PropertyInfo collection in collections)
            {
                //Taking the generic type arguments the current collection has ->
                //if we take the example with ICollection<Employee> => the generic argument would be 'Employee'.
                //We take only the first one, because we are 100% sure only one argument will be provided.
                Type collectionType = collection.PropertyType.GenericTypeArguments.First();

                //Creating a generic instance of the 'MapCollection' method of type <Department, Employee>
                MethodInfo mapCollectionGeneric = typeof(DbContext)
                    .GetMethod("MapCollection", BindingFlags.Instance | BindingFlags.NonPublic)
                    .MakeGenericMethod(entityType, collectionType);

                //Dynamically invoking the method
                mapCollectionGeneric.Invoke(this, new object[] { dbSet, collection });
            }
        }

        private void MapCollection<TDbSet, TCollection>(DbSet<TDbSet> dbSet, PropertyInfo collectionProperty)
            where TDbSet : class, new()
            where TCollection : class, new()
        {
            //entityType = Department
            //collectionType = Employee
            Type entityType = typeof(TDbSet);
            Type collectionType = typeof(TCollection);

            //Getting all primary keys from the Employee class
            PropertyInfo[] primaryKeys = collectionType
                .GetProperties()
                .Where(pi => pi.HasAttribute<KeyAttribute>())
                .ToArray();

            PropertyInfo primaryKey = primaryKeys.First();
            //Department primary key -> Id
            PropertyInfo foreignKey = entityType
                .GetProperties()
                .First(pi => pi.HasAttribute<KeyAttribute>());

            bool isManyToMany = primaryKeys.Length > 1;
            if (isManyToMany)
            {
                primaryKey = collectionType
                    .GetProperties()
                    .First(pi =>
                        collectionType.GetProperty(pi.GetCustomAttribute<ForeignKeyAttribute>().Name).PropertyType ==
                        entityType);
            }

            DbSet<TCollection> navigationDbSet = (DbSet<TCollection>) this.dbSetProperties[collectionType].GetValue(this);
            foreach (TDbSet entity in dbSet)
            {
                object? primaryKeyValue = foreignKey.GetValue(entity);

                TCollection[] navigationEntities = navigationDbSet
                    .Where(navigationEntity => primaryKey.GetValue(navigationEntity).Equals(primaryKeyValue))
                    .ToArray();
                
                ReflectionHelper.ReplaceBackingField(entity, collectionProperty.Name, navigationEntities);
            }
        }

        private void MapNavigationProperties<TEntity>(DbSet<TEntity> dbSet)
            where TEntity : class, new()
        {
            //TEntity = Employee.
            Type entityType = typeof(TEntity);
            //Taking all properties, which have the 'ForeignKeyAttribute'.
            PropertyInfo[] foreignKeys = entityType
                .GetProperties()
                .Where(pi => pi.HasAttribute<ForeignKeyAttribute>())
                .ToArray();

            foreach (PropertyInfo foreignKey in foreignKeys)
            {
                //Getting the name of the navigation property - for example - Department
                string navigationPropertyName = foreignKey.GetCustomAttribute<ForeignKeyAttribute>().Name;

                //Getting the actual navigation property Department Department
                PropertyInfo navigationProperty = entityType.GetProperty(navigationPropertyName);

                //Getting the dbSet, which contains the navigation property -> DbSet<Department>.
                object? navigationDbSet = this.dbSetProperties[navigationProperty.PropertyType].GetValue(this);

                //Getting the primary key of the navigation property.
                PropertyInfo navigationPrimaryKey = navigationProperty
                    .PropertyType
                    .GetProperties()
                    .First(pi => pi.HasAttribute<KeyAttribute>());

                foreach (TEntity entity in dbSet)
                {
                    //Getting the value of the foreign key for Department (DepartmentId), which is
                    //inside the Employee.
                    object? foreignKeyValue = foreignKey.GetValue(entity);

                    //Getting the exact Department, whose primary key (PK) is equal to the foreign key in
                    //the Employee (Id (from Department) = DepartmentId (from Employee)).
                    object? navigationPropertyValue = ((IEnumerable<object?>)navigationDbSet)
                        .First(currentNavigationProperty =>
                            navigationPrimaryKey.GetValue(currentNavigationProperty).Equals(foreignKeyValue));

                    //Setting the value for the current entity
                    navigationProperty.SetValue(entity, navigationPropertyValue);
                }
            }
        }

        private IEnumerable<TEntity> LoadTableEntities<TEntity>()
            where TEntity : class, new()
        {
            Type tableType = typeof(TEntity);
            string[] columnNames = GetEntityColumnNames(tableType);
            string tableName = GetTableName(tableType);
            TEntity[] fetchedRows = this.connection.FetchResultSet<TEntity>(tableName, columnNames).ToArray();
            return fetchedRows;
        }
        private static bool IsObjectValid(object obj)
        {
            //Checking whether all the 'requirements' for the attributes have been met
            ValidationContext validationContext = new ValidationContext(obj);
            List<ValidationResult> validationErrors = new List<ValidationResult>();
            return Validator.TryValidateObject(obj, validationContext, validationErrors, true);
        }

        private string GetTableName(Type tableType)
        {
            string? tableName = ((TableAttribute?)Attribute.GetCustomAttribute(tableType, typeof(TableAttribute)))?.Name;
            if (tableName == null)
            {
                tableName = dbSetProperties[tableType].Name;
            }

            return tableName;
        }

        private Dictionary<Type, PropertyInfo> DiscoverDbSets()
            => GetType().GetProperties().Where(pi => pi.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>))
                .ToDictionary(pi => pi.PropertyType.GenericTypeArguments.First(), pi => pi);

        private string[] GetEntityColumnNames(Type tableType)
        {
            //Get table name.
            string tableName = GetTableName(tableType);
            //Get all the column names present in the table.
            string[] dbColumns = this.connection.FetchColumnNames(tableName).ToArray();

            //Filter out all the columns which do not fulfill all the requirements.
            string[] columns = tableType
                .GetProperties()
                .Where(pi => dbColumns.Contains(pi.Name) &&
                                        !pi.HasAttribute<NotMappedAttribute>() &&
                                        AllowedSqlTypes.Contains(pi.PropertyType))
                .Select(pi => pi.Name)
                .ToArray();

            return columns;
        }
    }
}
