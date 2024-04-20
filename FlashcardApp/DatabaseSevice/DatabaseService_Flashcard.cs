using Microsoft.Data.SqlClient;
using Dapper;

internal class MSSQLDatabaseFlashcard
{
    string connectionString;
    public MSSQLDatabaseFlashcard()
    {
        this.connectionString = ConfigurationService.GetSqlConnectionString("mssql");
    }
    
    public void DeleteCard(int cardId)
    {
        string commandInput = $"DELETE FROM CARDS WHERE Id={cardId}";
        TExecuteNonQuerySQL(commandInput);
    }
    public void CreateNewCard(string front, string back, int stackId)
    {
        string commandInput = $"INSERT INTO CARDS (front,back,stack_id) VALUES ('{front}','{back}',{stackId})";
        TExecuteNonQuerySQL(commandInput);
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
    public bool TDapperExecuteScalarExist(string commandInput) //check if record exists in db 
    {
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();
            bool exist = connection.ExecuteScalar<bool>(commandInput);
            return exist;
        }
    }
    public bool IsRecordExistsById(int id)
    {
        string commandInput = $"select count(1) from CARDS where Id={id}";
        return TDapperExecuteScalarExist(commandInput);
    }

    public List<CardDTO> GetAllCards(int stackID)
    {
        string commandInput = $"SELECT * FROM CARDS WHERE stack_id={stackID}";
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();
            return (List<CardDTO>)connection.Query<CardDTO>(commandInput);

        }
    }

    public void UpdateCard(int cardId, string front, string back)
    {
        string commandInput = $"UPDATE CARDS SET front='{front}', back='{back}' WHERE id={cardId}";
        TExecuteNonQuerySQL(commandInput);
    }

    
}