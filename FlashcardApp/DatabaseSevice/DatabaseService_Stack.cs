
using Microsoft.Data.SqlClient;
using Dapper;

internal class MSSQLDatabaseStack
{
    string connectionString;
    public MSSQLDatabaseStack()
    {
        this.connectionString = ConfigurationService.GetSqlConnectionString("mssql");
    }
    public bool AddToStackTableSQL(string name)
    {
        if(IsExistInStackTableSQLByName(name)) 
            return false; 
        string commandInput = $"INSERT INTO STACKS (name) values ('{name}')";
        TExecuteNonQuerySQL(commandInput);
        return true;
    }

    public bool IsRecordExistsById(int id)
    {
        string commandInput = $"select count(1) from STACKS where Id={id}";
        return TDapperExecuteScalarExist(commandInput);
    }
    public bool IsExistInStackTableSQLByName(string name)
    {
        string commandInput = $"select count(1) from STACKS where name='{name}'";
        return TDapperExecuteScalarExist(commandInput);
    }

    public bool UpdateStack(int id, string name)
    {
        if(IsExistInStackTableSQLByName(name)) 
            return false; 
        string commandInput = $"UPDATE STACKS SET name = '{name}' WHERE Id={id}";
        TExecuteNonQuerySQL(commandInput);
        return true;
    }
    public void TExecuteNonQuerySQL(string commandInput)
    {
        using(var connection = new SqlConnection(connectionString))
        {
            connection.Open();
            using (var tableCmd = connection.CreateCommand())
            {
                tableCmd.CommandText = commandInput;
                tableCmd.ExecuteNonQuery();
            }
        }
        
    }

    public List<Stack> TDapperGetAllStack(string commandInput)
    {
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();
            return (List<Stack>)connection.Query<Stack>(commandInput);

        }
    }
    public void DeleteStack(int stackId)
    {
        string commandInput = $"DELETE FROM STACKS WHERE Id={stackId}";
        TExecuteNonQuerySQL(commandInput);

    }
    public string TDapperGetStackNameById(int stackId)
    {
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();
            return connection.ExecuteScalar<string>($"SELECT name FROM STACKS WHERE Id={stackId}");
        }
    }

    public bool TDapperExecuteScalarExist(string commandInput) //check if record exists in db 
    {
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();
            bool exist = connection.ExecuteScalar<bool>(commandInput);
            return exist;
        }
    }


}