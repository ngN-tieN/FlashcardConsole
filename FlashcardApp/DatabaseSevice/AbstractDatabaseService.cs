using Dapper;
using Microsoft.Data.SqlClient;
abstract class AbstractDatabaseService
{
    private string connectionString;
    public AbstractDatabaseService()
    {
        this.connectionString = ConfigurationService.GetSqlConnectionString("mssql");
    }
    public string GetConnectionString()
    {
        return this.connectionString;
    }
   
}