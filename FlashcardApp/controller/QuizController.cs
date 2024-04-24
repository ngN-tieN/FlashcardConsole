class QuizController
{
    private DatabaseServiceQuiz dbService = new();
    public List<StudyCardDTO> GetAllQuizzes(int stackId)
    {
        Console.Clear();
        return dbService.GetAllQuizzes(stackId);
    }
}