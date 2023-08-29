namespace MiniORM
{
    using System.ComponentModel.DataAnnotations;
    using System.Reflection;

    internal class ChangeTracker<TEntity>
     where TEntity : class, new()
    {
        private readonly IList<TEntity> allEntities;
        private readonly IList<TEntity> added;
        private readonly IList<TEntity> removed;

        private ChangeTracker()
        {
            this.added = new List<TEntity>();
            this.removed = new List<TEntity>();
        }

        public ChangeTracker(IEnumerable<TEntity> entities)
        {
            this.allEntities = CloneEntities(entities);
        }
        public IReadOnlyCollection<TEntity> AllEntities => (IReadOnlyCollection<TEntity>) this.allEntities;
        public IReadOnlyCollection<TEntity> Added => (IReadOnlyCollection<TEntity>) this.added;
        public IReadOnlyCollection<TEntity> Removed => (IReadOnlyCollection<TEntity>) this.removed;

        public void Add(TEntity entity) => this.added.Add(entity);
        public void Remove(TEntity entity) => this.removed.Add(entity);

        public IEnumerable<TEntity> GetModifiedEntities(DbSet<TEntity> dbSet)
        {
            List<TEntity> modifiedEntities = new List<TEntity>();
            //Take all the properties of the TEntity type, which have the KeyAttribute (used for PKs)
            PropertyInfo[] primaryKeys = typeof(TEntity)
                .GetProperties()
                .Where(pi => pi.HasAttribute<KeyAttribute>())
                .ToArray();

            foreach (TEntity proxyEntity in this.AllEntities)
            {
                object?[] primaryKeyValues = GetPrimaryKeyValues(primaryKeys, proxyEntity).ToArray();

                //We take the original entity for the DbSet, as we already have the proxy entity
                TEntity entity = dbSet.Entities
                    .Single(ent =>
                        GetPrimaryKeyValues(primaryKeys, ent).SequenceEqual(GetPrimaryKeyValues(primaryKeys, ent)));

                //Compare both entities and see if a change has been made in the proxy one
                bool isModified = IsModified(entity, proxyEntity);
                if (isModified)
                {
                    modifiedEntities.Add(proxyEntity);
                }
            }

            return modifiedEntities;
        }
        private static List<TEntity> CloneEntities(IEnumerable<TEntity> entities)
        {
            List<TEntity> clonedEntities = new List<TEntity>();

            //We get all properties which are of the allowed SQL types.
            PropertyInfo[] propertiesToClone = typeof(TEntity)
                .GetProperties()
                .Where(pi => DbContext.AllowedSqlTypes.Contains(pi.PropertyType))
                .ToArray();

            //foreach Employee in Employees
            foreach (TEntity entity in entities)
            {
                //T = Employee
                TEntity clonedEntity = Activator.CreateInstance<TEntity>();
                foreach (PropertyInfo property in propertiesToClone)
                {
                    //Getting the property value from the original entity (from the database)
                    object? value = property.GetValue(entity);
                    //We set the property value of a specified object -> T = Employee
                    property.SetValue(clonedEntity, value);
                }
                clonedEntities.Add(entity);
            }

            return clonedEntities;
        }

        private static bool IsModified(TEntity entity, TEntity proxyEntity)
        {
            //We take all the valid properties of the entity type (Employee).
            PropertyInfo[] monitoredProperties = typeof(TEntity)
                .GetProperties()
                .Where(pi => DbContext.AllowedSqlTypes.Contains(pi.PropertyType))
                .ToArray();

            //We go through every valid property and check -> is the value of the current entity
            //equal to the value of the proxy entity, if so, then the property has been modified.
            PropertyInfo[] modifiedProperties = monitoredProperties
                .Where(pi => !Equals(pi.GetValue(entity), pi.GetValue(proxyEntity)))
                .ToArray();

            return modifiedProperties.Any();
        }

        private static IEnumerable<object?> GetPrimaryKeyValues<T>(IEnumerable<PropertyInfo> primaryKeys, T entity)
            => primaryKeys.Select(pk => pk.GetValue(entity));
    }
}