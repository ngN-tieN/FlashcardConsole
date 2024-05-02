using Microsoft.Data.SqlClient;
using Dapper;

class DatabaseServiceStudySession:AbstractDatabaseServiceEntity
{
    public void CreateSession(int stackId, int score)
    {
        string commandInput = $"INSERT INTO STUDY_SESSIONS (score, stack_id) VALUES ({score}, {stackId})";
        DapperExecuteNonQuerySQL(commandInput);
    }

    public List<StudySessionDTO> GetAllSession()
    {
        string commandInput = @"SELECT STUDY_SESSIONS.Id, STUDY_SESSIONS.Score, 
                                        STUDY_SESSIONS.Date, STACKS.Name AS StackName
                                FROM STUDY_SESSIONS 
                                INNER JOIN STACKS
                                ON STACKS.Id = STUDY_SESSIONS.Stack_id";
        using (var connection = new SqlConnection(this.GetConnectionString()))
        {
            connection.Open();
            var list = connection.Query<StudySessionDTO>(commandInput);
            return (List<StudySessionDTO>) list;

        }
    }
    public List<SummaryDTO> SummaryBySessionsPerMonth(int year)
    {
        string commandInput = string.Format(@"CREATE OR ALTER VIEW STUDYSESSIONSBYMONTH AS
	                            SELECT STUDY_SESSIONS.Id as ID, MONTH(STUDY_SESSIONS.Date) AS MONTHLY,
							    STACKS.Name FROM STUDY_SESSIONS 
                                INNER JOIN STACKS
                                ON STACKS.Id = STUDY_SESSIONS.Stack_id
								WHERE YEAR(STUDY_SESSIONS.Date) = {0}", year); 
        DapperExecuteNonQuerySQLSilent(commandInput);
        commandInput = @"SELECT  Name,
		                IsNull([1], 0) as Jan,
		                IsNull([2], 0) as Feb, 
		                IsNull([3], 0) as Mar, 
                        IsNull([4], 0) as Apr, 
                        IsNull([5], 0) as May, 
                        IsNull([6], 0) as Jun, 
                        IsNull([7], 0) as Jul, 
                        IsNull([8], 0) as Aug, 
                        IsNull([9], 0) as Sep,
                        IsNull([10], 0) as Oct, 
                        IsNull([11], 0) as Nov, 
                        IsNull([12], 0) as Dec
                        FROM STUDYSESSIONSBYMONTH 
                        PIVOT(COUNT(Id) FOR MONTHLY IN ([1], [2] , [3] , [4] , [5], [6], [7], [8], [9], [10], [11], [12])) DT1
                        ";
        using (var connection = new SqlConnection(this.GetConnectionString()))
        {
            connection.Open();
            var list = connection.Query<SummaryDTO>(commandInput);
            return (List<SummaryDTO>) list;

        }
    }
    public List<SummaryDTO> SummaryByAvgScorePerMonth(int year)
    {
        string commandInput = string.Format(@"CREATE OR ALTER VIEW STUDYSESSIONSBYMONTH_AVGSCORE AS
	                            SELECT  STUDY_SESSIONS.SCORE, MONTH(STUDY_SESSIONS.Date) AS MONTHLY,
							    STACKS.Name FROM STUDY_SESSIONS 
                                INNER JOIN STACKS
                                ON STACKS.Id = STUDY_SESSIONS.Stack_id
								WHERE YEAR(STUDY_SESSIONS.Date) = {0}", year); 
        DapperExecuteNonQuerySQLSilent(commandInput);
        commandInput = @"SELECT  Name, 
                                    IsNull([1], 0) as Jan,
                                    IsNull([2], 0) as Feb, 
                                    IsNull([3], 0) as Mar, 
                                    IsNull([4], 0) as Apr, 
                                    IsNull([5], 0) as May, 
                                    IsNull([6], 0) as Jun, 
                                    IsNull([7], 0) as Jul, 
                                    IsNull([8], 0) as Aug, 
                                    IsNull([9], 0) as Sep,
                                    IsNull([10], 0) as Oct, 
                                    IsNull([11], 0) as Nov, 
                                    IsNull([12], 0) as Dec
                            FROM STUDYSESSIONSBYMONTH_AVGSCORE 
                            PIVOT(AVG(SCORE) FOR MONTHLY IN ([1], [2] , [3] , [4] , [5], [6], [7], [8], [9], [10], [11], [12])) DT1	
                        ";
        using (var connection = new SqlConnection(this.GetConnectionString()))
        {
            connection.Open();
            var list = connection.Query<SummaryDTO>(commandInput);
            return (List<SummaryDTO>) list;

        }
    }
}