using static Utils.GetFromConsole;
using static Utils.RandomShuffle;
class StudySessionController
{
    public void StudyStack(int stackId, string stackName, List<StudyCardDTO> quizzesList)
    {
        quizzesList = GenerateRandomQuestions(quizzesList);
        
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