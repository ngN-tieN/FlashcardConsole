using Microsoft.Data.SqlClient;
using Dapper;

class DatabaseServiceFlashcard:DatabaseServiceCRUD
{
    
    public void CreateNewCard(string front, string back, int stackId)
    {
        string commandInput = $"INSERT INTO CARDS (front,back,stack_id) VALUES ('{front}','{back}',{stackId})";
        DapperExecuteNonQuerySQL(commandInput);
    }    
    public List<CardDTO> GetAllCards(int stackID)
    {
        string commandInput = $"SELECT * FROM CARDS WHERE stack_id={stackID}";
        using (var connection = new SqlConnection(this.GetConnectionString()))
        {
            connection.Open();
            return (List<CardDTO>)connection.Query<CardDTO>(commandInput);

        }
    }
    public void UpdateCard(int cardId, string front, string back)
    {
        string commandInput = $"UPDATE CARDS SET front='{front}', back='{back}' WHERE id={cardId}";
        DapperExecuteNonQuerySQL(commandInput);
    }
    public void DeleteCard(int cardId)
    {
        string commandInput = $"DELETE FROM CARDS WHERE Id={cardId}";
        DapperExecuteNonQuerySQL(commandInput);
    }

  
   
    public bool IsRecordExistsById(int id)
    {
        string commandInput = $"select count(1) from CARDS where Id={id}";
        return DapperExecuteScalarExist(commandInput);
    }




    
}