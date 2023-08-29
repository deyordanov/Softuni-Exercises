using System.ComponentModel.DataAnnotations;
using Microsoft.Data.SqlClient;
/// <summary>
/// Used for accessing a database, inserting/updating/deleting entities
/// and mapping database columns to entity classes.
/// </summary>
namespace MiniORM;

using System.Reflection;

internal class DatabaseConnection
{
    private readonly SqlConnection connection;

    private SqlTransaction transaction;

    public DatabaseConnection(string connectionString)
    {
        this.connection = new SqlConnection(connectionString);
    }

    private SqlCommand CreateCommand(string queryText, params SqlParameter[] parameters)
    {
        var command = new SqlCommand(queryText, this.connection, this.transaction);

        foreach (var param in parameters)
        {
            command.Parameters.Add(param);
        }

        return command;
    }

    public int ExecuteNonQuery(string queryText, params SqlParameter[] parameters)
    {
        using (var query = CreateCommand(queryText, parameters))
        {
            var result = query.ExecuteNonQuery();

            return result;
        }
    }

    public IEnumerable<string> FetchColumnNames(string tableName)
    {
        List<string> rows = new List<string>();
        //Query which returns all the names of the table with the provided name
        string queryText = $@"SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{tableName}'";

        using SqlCommand query = CreateCommand(queryText);
        using SqlDataReader reader = query.ExecuteReader();
        //Use ADO.NET and add all column names to the collection
        while (reader.Read())
        {
            string? column = reader.GetString(0);

            rows.Add(column);
        }

        return rows;
    }

    public IEnumerable<T> ExecuteQuery<T>(string queryText)
    {
        var rows = new List<T>();

        using (var query = CreateCommand(queryText))
        {
            using (var reader = query.ExecuteReader())
            {
                while (reader.Read())
                {
                    var columnValues = new object[reader.FieldCount];
                    reader.GetValues(columnValues);

                    var obj = reader.GetFieldValue<T>(0);
                    rows.Add(obj);
                }
            }
        }

        return rows;
    }

    public IEnumerable<T> FetchResultSet<T>(string tableName, params string[] columnNames)
    {
        var rows = new List<T>();

        var escapedColumns = string.Join(", ", columnNames.Select(EscapeColumn));
        var queryText = $@"SELECT {escapedColumns} FROM {tableName}";

        using var query = CreateCommand(queryText);
        using var reader = query.ExecuteReader();
        while (reader.Read())
        {
            //We retrieve all the column values at once
            var columnValues = new object[reader.FieldCount];
            reader.GetValues(columnValues);

            //Map all the values for the columns to an object
            var obj = MapColumnsToObject<T>(columnNames, columnValues);

            //The object represents one row from the table, we add it to the collection
            rows.Add(obj);
        }

        return rows;
    }

    public void InsertEntities<T>(IEnumerable<T> entities, string tableName, string[] columns)
        where T : class
    {
        //We get all the identity columns.
        IEnumerable<string> identityColumns = GetIdentityColumns(tableName);

        //We take all columns, except for the identity ones.
        string[] columnsToInsert = columns.Except(identityColumns).ToArray();

        //We escape the selected columns with '[]'.
        string[] escapedColumns = columnsToInsert.Select(EscapeColumn).ToArray();

        //We iterate through all entities and retrieve the value they have for each column.
        object?[][] rowValues = entities
            .Select(entity => columnsToInsert
                .Select(c => entity.GetType().GetProperty(c).GetValue(entity))
                .ToArray())
            .ToArray();

        //Append a number in front of each column.
        string[][] rowParameterNames = Enumerable.Range(1, rowValues.Length)
            .Select(i => columnsToInsert.Select(c => c + i).ToArray())
            .ToArray();

        //Join all the selected columns => [FirstName], [MiddleName], [LastName]... etc.
        string sqlColumns = string.Join(", ", escapedColumns);

        //Make variables out of the parameter names.
        string sqlRows = string.Join(", ",
            rowParameterNames.Select(p =>
                string.Format("({0})",
                    string.Join(", ", p.Select(a => $"@{a}")))));

        //Build up the final query => INSERT INTO Employees (FirstName) VALUES ('@FirstName1')
        string query = string.Format(
            "INSERT INTO {0} ({1}) VALUES {2}",
            tableName,
            sqlColumns,
            sqlRows
        );

        //Parametrize the query => prevent SQL Injection
        SqlParameter[] parameters = rowParameterNames
            .Zip(rowValues, (@params, values) =>
                @params.Zip(values, (param, value) =>
                    new SqlParameter(param, value ?? DBNull.Value)))
            .SelectMany(p => p)
            .ToArray();

        //Execute the query
        var insertedRows = this.ExecuteNonQuery(query, parameters);

        //If the counts do not match -> we throw an exception
        if (insertedRows != entities.Count())
        {
            throw new InvalidOperationException($"Could not insert {entities.Count() - insertedRows} rows.");
        }
    }

    public void UpdateEntities<T>(IEnumerable<T> modifiedEntities, string tableName, string[] columns)
        where T : class
    {
        //We retrieve the identity columns
        IEnumerable<string> identityColumns = GetIdentityColumns(tableName);

        //Take all columns except for the identity ones
        string[] columnsToUpdate = columns.Except(identityColumns).ToArray();

        //Get all properties which are primary keys (have the 'KeyAttribute') for the current entity (Employees)
        PropertyInfo[] primaryKeyProperties = typeof(T)
            .GetProperties()
            .Where(pi => pi.HasAttribute<KeyAttribute>())
            .ToArray();

        foreach (T entity in modifiedEntities)
        {
            //Get the primary key values for the current entity (Employee)
            object?[] primaryKeyValues = primaryKeyProperties
                .Select(c => c.GetValue(entity))
                .ToArray();

            //The .Zip() method is used to merge two sequences by using a predicate
            //In this case we use the parameter name from 'primaryKeyProperties' as the SqlParameter name
            //and the value from 'primaryKeyValues' for the current entity as the SqlParameter value
            SqlParameter[] primaryKeyParameters = primaryKeyProperties
                .Zip(primaryKeyValues, (param, value) => new SqlParameter(param.Name, value))
                .ToArray();

            //Maps all the values from the current entity to all the columns we are going to update
            //If any value is null, then it will be replaced with DbNull.Value
            object[] rowValues = columnsToUpdate
                .Select(c => entity.GetType().GetProperty(c).GetValue(entity) ?? DBNull.Value)
                .ToArray();

            //Parametrize values
            var columnsParameters = columnsToUpdate.Zip(rowValues, (param, value) => new SqlParameter(param, value))
                .ToArray();

            var columnsSql = string.Join(", ",
                columnsToUpdate.Select(c => $"{c} = @{c}"));

            var primaryKeysSql = string.Join(" AND ",
                primaryKeyProperties.Select(pk => $"{pk.Name} = @{pk.Name}"));

            var query = string.Format("UPDATE {0} SET {1} WHERE {2}",
                tableName,
                columnsSql,
                primaryKeysSql);

            var updatedRows = this.ExecuteNonQuery(query, columnsParameters.Concat(primaryKeyParameters).ToArray());

            if (updatedRows != 1)
            {
                throw new InvalidOperationException($"Update for table {tableName} failed.");
            }
        }
    }

    public void DeleteEntities<T>(IEnumerable<T> entitiesToDelete, string tableName, string[] columns)
        where T : class
    {
        PropertyInfo[] primaryKeyProperties = typeof(T).GetProperties()
            .Where(pi => pi.HasAttribute<KeyAttribute>())
            .ToArray();

        foreach (T entity in entitiesToDelete)
        {
            object?[] primaryKeyValues = primaryKeyProperties
                .Select(c => c.GetValue(entity))
                .ToArray();

            SqlParameter[] primaryKeyParameters = primaryKeyProperties
                .Zip(primaryKeyValues, (param, value) => new SqlParameter(param.Name, value))
                .ToArray();

            string primaryKeysSql = string.Join(" AND ",
                primaryKeyProperties.Select(pk => $"{pk.Name} = @{pk.Name}"));

            string query = string.Format("DELETE FROM {0} WHERE {1}",
                tableName,
                primaryKeysSql);

            int updatedRows = this.ExecuteNonQuery(query, primaryKeyParameters);

            if (updatedRows != 1)
            {
                throw new InvalidOperationException($"Delete for table {tableName} failed.");
            }
        }
    }

    private IEnumerable<string> GetIdentityColumns(string tableName)
    {
        const string identityColumnsSql =
            "SELECT COLUMN_NAME FROM (SELECT COLUMN_NAME, COLUMNPROPERTY(OBJECT_ID(TABLE_NAME), COLUMN_NAME, 'IsIdentity') AS IsIdentity FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{0}') AS IdentitySpecs WHERE IsIdentity = 1";
        //INFORMATION_SCHEMA.COLUMNS provides information about all the tables in the current database
        //In our case, the query filters columns from a given table - table names replaces '{0}'
        //For every column it calculates a value using the 'COLUMNPROPERTY' function, which returns the value
        //of a specified column property for a column in the table. In this query, it checks the 'isIdentity'
        // property. This property returns '1', if the column is an identity column and '0' otherwise.
        //Lastly we select all the column names, where this function returns '1'.That is how we retrieve all the
        //identity columns.

        string parametrizedSql = string.Format(identityColumnsSql, tableName);

        IEnumerable<string> identityColumns = ExecuteQuery<string>(parametrizedSql);

        return identityColumns;
    }

    public SqlTransaction StartTransaction()
    {
        this.transaction = this.connection.BeginTransaction();
        return this.transaction;
    }

    public void Open() => this.connection.Open();

    public void Close() => this.connection.Close();

    private static string EscapeColumn(string c)
    {
        var escapedColumn = $"[{c}]";
        return escapedColumn;
    }

    private static T MapColumnsToObject<T>(string[] columnNames, object[] columns)
    {
        // Create an instance of the current type
        var obj = Activator.CreateInstance<T>();

        for (var i = 0; i < columns.Length; i++)
        {
            var columnName = columnNames[i];
            var columnValue = columns[i];

            if (columnValue is DBNull)
            {
                columnValue = null;
            }

            var property = typeof(T).GetProperty(columnName);
            //Set the value of the property for the current instance
            property.SetValue(obj, columnValue);
        }

        return obj;
    }
}
