using Microsoft.Data.SqlClient;
using Dapper;
class DatabaseServiceQuiz:AbstractDatabaseServiceEntity
{
    public List<StudyCardDTO> GetAllQuizzes(int stackID)
    {
        string commandInput = $"SELECT * FROM CARDS WHERE stack_id={stackID}";
        using (var connection = new SqlConnection(this.GetConnectionString()))
        {
            connection.Open();
            return (List<StudyCardDTO>)connection.Query<StudyCardDTO>(commandInput);

        }
    }
}