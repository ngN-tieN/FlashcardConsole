
using Microsoft.Data.SqlClient;
using Dapper;

class DatabaseServiceStack:AbstractDatabaseServiceEntity
{
    
    public bool CreateStack(string name)
    {
        if(IsExistInStackTableSQLByName(name)) 
            return false; 
        string commandInput = $"INSERT INTO STACKS (name) values ('{name}')";
        DapperExecuteNonQuerySQL(commandInput);
        return true;
    }
    public List<Stack> GetAllStack()
    {
        string commandInput = "SELECT * FROM STACKS ORDER BY Id";
        using (var connection = new SqlConnection(this.GetConnectionString()))
        {
            connection.Open();
            return (List<Stack>)connection.Query<Stack>(commandInput);

        }
    }
    public bool UpdateStack(string oldName, string newName)
    {
        if(IsExistInStackTableSQLByName(newName)) 
            return false; 
        string commandInput = $"UPDATE STACKS SET name = '{newName}' WHERE name = '{oldName}' ";
        DapperExecuteNonQuerySQL(commandInput);
        return true;
    }
    public void DeleteStack(string stackName)
    {
        string commandInput = $"DELETE FROM STACKS WHERE name = '{stackName}'";
        DapperExecuteNonQuerySQL(commandInput);

    }
    public bool IsRecordExistsByName(string name)
    {
        string commandInput = $"select count(1) from STACKS where name='{name}'";
        return DapperExecuteScalarExist(commandInput);
    }
    public bool IsExistInStackTableSQLByName(string name)
    {
        string commandInput = $"select count(1) from STACKS where name='{name}'";
        return DapperExecuteScalarExist(commandInput);
    }


    
    


    public int DapperGetStackIDByName(string name)
    {
        using (var connection = new SqlConnection(this.GetConnectionString()))
        {
            connection.Open();
            return connection.ExecuteScalar<int>($"SELECT id FROM STACKS WHERE name='{name}'");
        }
    }

    


}