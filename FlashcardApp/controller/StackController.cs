using Microsoft.VisualBasic;
using static Utils.GetFromConsole;
using static Utils.TableExt;
using static Utils.Wait;
internal class StackController
{
    private DatabaseServiceStack dbService = new();
    public void ShowStackControllerOptions()
    {
        bool stop = false;
        while(!stop)
        {
            Console.Clear();
            Console.WriteLine("\n\n\t\t\tYOUR FLASHCARDS STACKS");
            GetAllStacks();
            Console.WriteLine("\n\t\t\tWhat would you like to do?");
            Console.WriteLine("\nType 0 to close app.");
            Console.WriteLine("\nType C to create new stack.");
            Console.WriteLine("\nType D to delete stack.");
            Console.WriteLine("\nType E to update stack.");
            Console.WriteLine("\nType S to study stack.");
            Console.WriteLine("\nType V to view all study sessions.");
            Console.WriteLine("\nType stack name to access to stack.");
            string options = Console.ReadLine(); 
            
            switch(options.Trim().ToUpper())
            {
                case "0":
                    stop = true;
                    break;
                case "D":
                    DeleteStack();
                    break;
                case "E":
                    UpdateStack();
                    break;
                case "C":
                    CreateStack();
                    break;
                case "S":
                    StudyStack();
                    break;
                case "V":
                    ViewAllSessions();
                    break;
                default:
                    SelectStack(options);
                    break;
            }
        }      
    }
    public void GetAllStacks()
    {
        
        var stacks = dbService.GetAllStack();
        printStackTable(stacks);
    }

    public void CreateStack()
    {
        Console.Clear();
        string name = GetString("Enter stack name");
        if(!dbService.CreateStack(name)) 
            Console.WriteLine("Name already exist!");
        return;
    }

    public void UpdateStack()
    {
        Console.Clear();
        string stackName = GetString("Enter stack name: ");
        if(!IsStackExistsByName(stackName)) 
        {
            Console.WriteLine("Name not found");
            WaitForExit();
            return;
        }

        string newStackName = GetString("Enter new stack name");
        if(!UpdateStackByName(stackName, newStackName))
            Console.WriteLine("Name already exist");
        WaitForExit();
    }

    public void DeleteStack()
    {
        Console.Clear();
        string stackName = GetString("Enter stack name: ");
        if(!IsStackExistsByName(stackName)) 
        {
            Console.WriteLine("Name not found");
            WaitForExit();
            return;
        }

        dbService.DeleteStack(stackName);
        WaitForExit();

    }
    public bool IsStackExistsByName(string stackName)
    {
        return dbService.IsRecordExistsByName(stackName);
    }
    public bool UpdateStackByName(string oldName, string newName)
    {
        return dbService.UpdateStack(oldName, newName);
    }
    
    public void SelectStack(string stackName)
    {
        Console.Clear();
        if(!IsStackExistsByName(stackName)) 
        {
            Console.WriteLine("Name not found");
            WaitForExit();
            return;
        }
        int stackId = dbService.DapperGetStackIDByName(stackName);
        var FlashcardController = new FlashcardController();
        FlashcardController.ShowFlashcardControllerOptions(stackId, stackName);
    }    
    public void StudyStack()
    {
        Console.Clear();
        GetAllStacks();
        string stackName = GetString("Type stack name to study stack.");
        if(!IsStackExistsByName(stackName)) 
        {
            Console.WriteLine("Name not found");
            WaitForExit();
            return;
        }
        int stackId = dbService.DapperGetStackIDByName(stackName);

        var QuizController = new QuizController();
        var quizzesList = QuizController.GetAllQuizzes(stackId);
        var StudySessionController = new StudySessionController();
        StudySessionController.StudyStack(stackId, stackName, quizzesList);
    }
    public void ViewAllSessions()
    {
        Console.Clear();
        var StudySessionController = new StudySessionController();
        bool stop = false;
        while(!stop)
        {
            Console.Clear();
            Console.WriteLine("\n\n\t\t\tView Session");
            GetAllStacks();
            Console.WriteLine("\n\t\t\tWhat would you like to do?");
            Console.WriteLine("\nType 0 to return to main menu.");
            Console.WriteLine("\nType 1 to View all session.");
            Console.WriteLine("\nType 2 to View summary sessions per month.");
            Console.WriteLine("\nType 3 to View average score per month.");
            string options = GetString("Please enter your option");
            int year;
            string[] month = ["Stack Name","Jan","Feb","Mar","Apr","May","Jun","Jul","Aug","Sep","Oct","Nov","Dec"];
            switch(options)
            {
                case "1":
                    var sessionsList = StudySessionController.GetAllSession();
                    printSessionsTable(sessionsList, "Study Sessions");
                    WaitForExit();
                    break;
                case "2":
                    year = GetInt("Enter a year in format YYYY");
                    var summaryListSession = StudySessionController.SummaryBySessionsPerMonth(year);
                    
                    printSummaryTable(summaryListSession, $"Sessions per month for {year}", month);
                    WaitForExit();
                    break;
                case "3":
                    year = GetInt("Enter a year in format YYYY");
                    var summaryListSessionAVG = StudySessionController.SummaryByAvgScorePerMonth(year);
                    printSummaryTable(summaryListSessionAVG, $"Average scores per month for {year}", month);
                    WaitForExit();
                    break;
                case "0":
                    stop = true;
                    break;
                default:
                    Console.WriteLine("Option not found!");
                    WaitForExit();
                    break;
            }
        }
        
    }

}