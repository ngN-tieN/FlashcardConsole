internal class FlashcardController
{
    public void ShowFlashcardControllerOptions(int stackID, string stackName)
    {
        Console.Clear();
        bool stop = false;
        while(!stop)
        {
            Console.WriteLine($"Curren stack: {stackName}");
            Console.WriteLine("\n\t\t\tWhat would you like to do?");
            Console.WriteLine("\nType 0 to return to main menu.");
            Console.WriteLine("\nType V to view all cards.");
            Console.WriteLine("\nType C to create new card.");
            Console.WriteLine("\nType D to delete card.");
            Console.WriteLine("\nType E to update card .");
            Console.WriteLine("\nType S to study stack.");
            string options = Console.ReadLine(); 
            
            switch(options.Trim().ToUpper())
            {
                case "0":
                    stop = true;
                    break;
                case "D":
                    break;
                case "E":
                    // UpdateStackById();
                    break;
                case "C":
                    // CreateNewStack();
                    break;
                default:
                    // int stackId;
                    // Int32.TryParse(options, out stackId);
                    // SelectStack(int stackId);
                    break;
            }
        }   
    }   
}