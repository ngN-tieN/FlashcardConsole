using Microsoft.VisualBasic;

internal class StackController
{
    private MSSQLDatabase dbService = new();
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
                    break;
                case "E":
                    break;
                case "C":
                    CreateNewStack();
                    break;
                default:
                    int stackId;
                    Int32.TryParse(options, out stackId);
                    // ShowOptionStack(int stackId);
                    break;
            }
        }      
    }
    public void GetAllStacks()
    {
        string commandInput = "SELECT * FROM STACKS";
        var stacks = dbService.TDapperGetAllStack(commandInput);
        tableExtService.printStackTable(stacks);
    }

    public void CreateNewStack()
    {
        string message = "Enter stack name";
        string name = GetString(message);
        if(!dbService.AddToStackTableSQL(name)) Console.WriteLine("Name already exist!");
        return;
    }

    internal String GetString(string msg)
    {
        Console.WriteLine(msg);
        return Console.ReadLine();

    }
}