using Microsoft.Data.SqlClient;
using Dapper;
abstract class AbstractDatabaseServiceEntity:AbstractDatabaseService, IDapperDatabaseService
{

    public void DapperExecuteNonQuerySQL(string sql)
    {
        using(var connection = new SqlConnection(this.GetConnectionString()))
        {
            var affectedRows =  connection.Execute(sql);
	        Console.WriteLine($"Affected Rows: {affectedRows}");
        }

    }
    public void DapperExecuteNonQuerySQLSilent(string sql)
    {
        using(var connection = new SqlConnection(this.GetConnectionString()))
        {
            var affectedRows =  connection.Execute(sql);
        }

    }
    public bool DapperExecuteScalarExist(string sql) //check if record exists in db 
    {
        using (var connection = new SqlConnection(this.GetConnectionString()))
        {
            connection.Open();
            bool exist = connection.ExecuteScalar<bool>(sql);
            return exist;
        }
    }
}