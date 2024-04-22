using Dapper;
using Microsoft.Data.SqlClient;
abstract class DatabaseService
{
    private string connectionString;
    public DatabaseService()
    {
        this.connectionString = ConfigurationService.GetSqlConnectionString("mssql");
    }
    public string GetConnectionString()
    {
        return this.connectionString;
    }
   
}