
using Microsoft.Data.SqlClient;

class MSSQLDatabase
{
    string connectionString;
    MSSQLDatabase()
    {
        this.connectionString = ConfigurationService.GetSqlConnectionString("mssql");
    }
    public void ConnectToDB()
    {
        using(var connection = new SqlConnection(connectionString)){
            connection.Open();
            var tableCmd = connection.CreateCommand();
            //need to be worked on
        }
    }
}