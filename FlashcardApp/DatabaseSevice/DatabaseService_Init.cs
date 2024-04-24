using Microsoft.Data.SqlClient;


class DatabaseInit:DatabaseService
{
    
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
        ExecuteNonQuerySQL(command);
        command = @"IF (OBJECT_ID('CARDS') IS NULL AND OBJECT_ID('STACKS') IS NOT NULL)	
                    BEGIN
                    CREATE TABLE CARDS
                    (
                        id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
                        front TEXT,
                        back TEXT, 
                        stack_id INT FOREIGN KEY REFERENCES STACKS(id) ON DELETE CASCADE
                    )
                    END";
        ExecuteNonQuerySQL(command);
        command = @"IF (OBJECT_ID('STUDY_SESSIONS') IS NULL AND OBJECT_ID('STACKS') IS NOT NULL)	
                    BEGIN
                    CREATE TABLE STUDY_SESSIONS
                    (
                        id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
                        score int,
                        date TIMESTAMP, 
                        stack_id INT FOREIGN KEY REFERENCES STACKS(id) ON DELETE CASCADE
                    )
                    END";
        ExecuteNonQuerySQL(command);
        
    }
    public void ExecuteNonQuerySQL(string commandInput)
    {
        using(var connection = new SqlConnection(this.GetConnectionString()))
        {
            connection.Open();
            using (var tableCmd = connection.CreateCommand())
            {
                tableCmd.CommandText = commandInput;
                tableCmd.ExecuteNonQuery();
            }
        }
        
    }

    
}