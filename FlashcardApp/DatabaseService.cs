
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
        using(var connection = new SqlConnection(connectionString)){
            connection.Open();
            var tableCmd = connection.CreateCommand();
            //The command to create 'stacks' table if
            //not exists
            string command = @"IF OBJECT_ID('STACKS') IS NULL
                            BEGIN
	                        CREATE TABLE STACKS
	                        (
		                        id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
		                        name varchar(255) unique
	                        )
                            END";
            tableCmd.CommandText = command;
            try
            {
                tableCmd.ExecuteNonQuery();
            }
            catch (System.Exception)
            {
                Console.WriteLine("Database error. Please try again");
            }
            //The command to create 'cards' table if
            //not exists and if the 'stacks' table is exists.

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
            tableCmd.CommandText = command;
             try
            {
                tableCmd.ExecuteNonQuery();
            }
            catch (System.Exception)
            {
                Console.WriteLine("Database error. Please try again");
            }
            connection.Close();
        }
    }
}