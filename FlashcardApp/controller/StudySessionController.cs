using static Utils.GetFromConsole;
using static Utils.RandomShuffle;
using static Utils.TableExt;
using static Utils.Wait;
class StudySessionController
{
    private DatabaseServiceStudySession dbService = new();
    public void StudyStack(int stackId, string stackName, List<StudyCardDTO> quizzesList)
    {
        quizzesList = GenerateRandomQuestions(quizzesList);
        int score = DoQuizzez(quizzesList);
        SaveSession(stackId, score);
        WaitForExit();
    }
    
    public void SaveSession(int stackId, int score)
    {
        Console.WriteLine("Saving Session.....");
        dbService.CreateSession(stackId, score);
    }

    public List<StudySessionDTO> GetAllSession()
    {
        Console.Clear();
        return dbService.GetAllSession();
    }

    public List<SummaryDTO> SummaryBySessionsPerMonth(int year)
    {
        Console.Clear();
        return dbService.SummaryBySessionsPerMonth(year);
    }
    public List<SummaryDTO> SummaryByAvgScorePerMonth(int year)
    {
        Console.Clear();
        return dbService.SummaryByAvgScorePerMonth(year);
    }
    public int DoQuizzez(List<StudyCardDTO> quizzesList)
    {
        
        int score = 0;
        foreach(var quiz in quizzesList)
        {
            Console.Clear();
            PrintQuiz(quiz);
            string answer = GetString("Enter answer or !x to calculate score").ToLower();
            if(answer.Equals("!x"))
            {
                break;
            }
            if(!AnswerIsTrue(answer, quiz)) 
            {
                Console.WriteLine($"Wrong! The answer is {quiz.Back}");
                continue;
            }   
            score++;
            Console.WriteLine($"Nice! The answer is {quiz.Back}");
            
        }
        Console.WriteLine($"You scored {score} out of {quizzesList.Count}.");
        return score;
        


    }
    public bool AnswerIsTrue(string answer, StudyCardDTO card)
    {
        return card.Back.ToLower().Equals(answer);
    }
    public void PrintQuiz(StudyCardDTO card)
    {
        printQuizTable(card.Front, " ");
    }
    public List<StudyCardDTO> GenerateRandomQuestions(List<StudyCardDTO> quizzesList)
    {
        quizzesList.Shuffle();
        return quizzesList;
    }
    
}