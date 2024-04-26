using static Utils.GetFromConsole;
using static Utils.RandomShuffle;
using static Utils.TableExt;
using static Utils.Wait;
class StudySessionController
{
    public void StudyStack(int stackId, string stackName, List<StudyCardDTO> quizzesList)
    {
        quizzesList = GenerateRandomQuestions(quizzesList);
        DoQuizzez(quizzesList);
        
    }
    
    public void DoQuizzez(List<StudyCardDTO> quizzesList)
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
        WaitForExit();


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
    /*to do list 
    calculate score
    print score
    input answer
    check answer
    print Quest*/
}