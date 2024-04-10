// See https://aka.ms/new-console-template for more information
class FlashcardApp
{
    public static void Main()
    {
        var dbService = new MSSQLDatabase();
        var StackController = new StackController();

        dbService.ConnectToDB();
         
        StackController.ShowStackControllerOptions();
    }
}