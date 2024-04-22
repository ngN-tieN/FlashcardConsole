// See https://aka.ms/new-console-template for more information
namespace FlashcardConsoleApp;
class FlashcardApp
{
    public static void Main()
    {
        DatabaseInit dbService = new ();
        var StackController = new StackController();

        dbService.ConnectToDB();
         
        StackController.ShowStackControllerOptions();
    }
}