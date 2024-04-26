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
            Console.WriteLine("\nType stack ID to access to stack.");
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
                default:
                    int stackId;
                    Int32.TryParse(options, out stackId);
                    SelectStack(stackId);
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
        int stackId = GetInt("Enter stack ID: ");
        if(!IsStackExistsById(stackId)) 
        {
            Console.WriteLine("ID not found");
            return;
        }

        string stackName = GetString("Enter new stack name");
        if(!UpdateStackById(stackId:stackId,stackName:stackName))
            Console.WriteLine("Name already exist");
        WaitForExit();
    }

    public void DeleteStack()
    {
        Console.Clear();
        int stackId = GetInt("Enter stack ID: ");
        if(!IsStackExistsById(stackId)) 
        {
            Console.WriteLine("ID not found");
            return;
        }
        dbService.DeleteStack(stackId);
        WaitForExit();

    }
    public bool IsStackExistsById(int stackId)
    {
        return dbService.IsRecordExistsById(stackId);
    }
    public bool UpdateStackById(int stackId, string stackName)
    {
        return dbService.UpdateStack(stackId, stackName);
    }
    public string GetStackNameById(int stackId)
    {
        return dbService.DapperGetStackNameById(stackId);
    }
    public void SelectStack(int stackId)
    {
        Console.Clear();
        if(!IsStackExistsById(stackId)) 
        {
            Console.WriteLine("ID not found");
            return;
        }
        var FlashcardController = new FlashcardController();
        string stackName = GetStackNameById(stackId);
        FlashcardController.ShowFlashcardControllerOptions(stackId, stackName);
    }    
    public void StudyStack()
    {
        Console.Clear();
        GetAllStacks();
        int stackId = GetInt("Type stack ID to study stack. ");
        if(!IsStackExistsById(stackId)) 
        {
            Console.WriteLine("ID not found");
            return;
        }
        string stackName = GetStackNameById(stackId);
        var QuizController = new QuizController();
        var quizzesList = QuizController.GetAllQuizzes(stackId);
        var StudySessionController = new StudySessionController();
        StudySessionController.StudyStack(stackId, stackName, quizzesList);
    }

}