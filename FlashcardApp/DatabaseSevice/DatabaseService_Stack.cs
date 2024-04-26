
using Microsoft.Data.SqlClient;
using Dapper;

class DatabaseServiceStack:DatabaseServiceCRUD
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
    public bool UpdateStack(int id, string name)
    {
        if(IsExistInStackTableSQLByName(name)) 
            return false; 
        string commandInput = $"UPDATE STACKS SET name = '{name}' WHERE Id={id}";
        DapperExecuteNonQuerySQL(commandInput);
        return true;
    }
    public void DeleteStack(int stackId)
    {
        string commandInput = $"DELETE FROM STACKS WHERE Id={stackId}";
        DapperExecuteNonQuerySQL(commandInput);

    }
    public bool IsRecordExistsById(int id)
    {
        string commandInput = $"select count(1) from STACKS where Id={id}";
        return DapperExecuteScalarExist(commandInput);
    }
    public bool IsExistInStackTableSQLByName(string name)
    {
        string commandInput = $"select count(1) from STACKS where name='{name}'";
        return DapperExecuteScalarExist(commandInput);
    }


    
    


    public string DapperGetStackNameById(int stackId)
    {
        using (var connection = new SqlConnection(this.GetConnectionString()))
        {
            connection.Open();
            return connection.ExecuteScalar<string>($"SELECT name FROM STACKS WHERE Id={stackId}");
        }
    }

    


}