// See https://aka.ms/new-console-template for more information
namespace FlashcardConsoleApp;
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