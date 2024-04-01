
using Microsoft.Data.SqlClient;

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
        command = @"IF (OBJECT_ID('CARD') IS NULL AND OBJECT_ID('STACKS') IS NOT NULL)	
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
    public void TExecuteNonQuerySQL(string commandInput)
    {
        using var connection = new SqlConnection(connectionString);
        connection.Open();
        var tableCmd = connection.CreateCommand();
        tableCmd.CommandText = commandInput;
        tableCmd.ExecuteNonQuery();
    }
}