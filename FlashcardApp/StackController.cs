using Microsoft.VisualBasic;
using static Utils.GetFromConsole;
internal class StackController
{
    private MSSQLDatabaseStack dbService = new();
    private TableExt tableExtService = new();
    public void ShowStackControllerOptions()
    {
        bool stop = false;
        while(!stop)
        {
            Console.WriteLine("\n\n\t\t\tYOUR FLASHCARDS STACKS");
            GetAllStacks();
            Console.WriteLine("\n\t\t\tWhat would you like to do?");
            Console.WriteLine("\nType 0 to close app.");
            Console.WriteLine("\nType C to create new stack.");
            Console.WriteLine("\nType D to delete stack.");
            Console.WriteLine("\nType E to update stack.");
            Console.WriteLine("\nType stacks ID to access to stack.");
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
                    CreateNewStack();
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
        
        string commandInput = "SELECT * FROM STACKS ORDER BY Id";
        var stacks = dbService.TDapperGetAllStack(commandInput);
        tableExtService.printStackTable(stacks);
    }

    public void CreateNewStack()
    {
        Console.Clear();
        string name = GetString("Enter stack name");
        if(!dbService.AddToStackTableSQL(name)) 
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
        return;
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
        return dbService.TDapperGetStackNameById(stackId);
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
    
    
}