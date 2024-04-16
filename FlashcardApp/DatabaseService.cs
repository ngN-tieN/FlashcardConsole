
using Microsoft.Data.SqlClient;
using Dapper;

internal class MSSQLDatabase
{
    string connectionString;
    public MSSQLDatabase()
    {
        this.connectionString = ConfigurationService.GetSqlConnectionString("mssql");
    }
    public void ConnectToDB()
    {
        string command = @"IF OBJECT_ID('STACKS') IS NULL
                            BEGIN
	                        CREATE TABLE STACKS
	                        (
		                        id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
		                        name varchar(255) unique
	                        )
                            END";
        TExecuteNonQuerySQL(command);
        command = @"IF (OBJECT_ID('CARDS') IS NULL AND OBJECT_ID('STACKS') IS NOT NULL)	
                    BEGIN
                    CREATE TABLE CARDS
                    (
                        id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
                        front TEXT,
                        back TEXT, 
                        stack_id INT FOREIGN KEY REFERENCES STACKS(id)
                    )
                    END";
        TExecuteNonQuerySQL(command);
        
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