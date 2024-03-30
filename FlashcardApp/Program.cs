// See https://aka.ms/new-console-template for more information
class FlashcardApp
{
    public static void Main()
    {
        var dbService = new MSSQLDatabase();
        dbService.ConnectToDB();
         
        bool closeApp = false;
        while(!closeApp)
        {
            Console.WriteLine("\n\n\t\t\tYOUR FLASHCARDS STACKS");
            //GetAllStacks();
            Console.WriteLine("\n\t\t\tWhat would you like to do?");
            Console.WriteLine("\nType 0 to close app.");
            Console.WriteLine("\nType stacks ID to access to stack.");
            Int32.TryParse(Console.ReadLine(), out int options); 
            
            switch(options)
            {
                case 0:
                    closeApp = true;
                    break;
                default:
                    int stackId = options;
                    // GetAllFLashCardr(int stackId);
                    break;
            }
                
        }
    }
}