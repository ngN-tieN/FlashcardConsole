using static Utils.GetFromConsole;
internal class FlashcardController
{
    private DatabaseServiceFlashcard dbService = new();
    private TableExt tableExtService = new();
    public void ShowFlashcardControllerOptions(int stackID, string stackName)
    {
        Console.Clear();
        bool stop = false;
        while(!stop)
        {
            Console.WriteLine($"Current stack: {stackName}");
            Console.WriteLine("\n\t\t\tWhat would you like to do?");
            Console.WriteLine("\nType 0 to return to main menu.");
            Console.WriteLine("\nType V to view all cards.");
            Console.WriteLine("\nType C to create new card.");
            Console.WriteLine("\nType D to delete card.");
            Console.WriteLine("\nType E to update card.");
            Console.WriteLine("\nType S to study stack.");
            string options = Console.ReadLine(); 
            
            switch(options.Trim().ToUpper())
            {
                case "0":
                    stop = true;
                    break;
                case "V":
                    GetAllCards(stackID, stackName);
                    break;
                case "D":
                    DeleteCard(stackID, stackName);
                    break;
                case "E":
                    UpdateCard(stackID, stackName);
                    break;
                case "C":
                    CreateNewCard(stackID);
                    break;
                default:
                    Console.WriteLine("Option not found. Please try again");
                    break;
            }
        }   
    }   

    public void DeleteCard(int stackID, string stackName)
    {
        Console.Clear();
        var cardList = GetAllCards(stackID, stackName); 
        int cardDisplayID = GetInt("Enter card ID to delete");
        var card = cardList.Find(card => card.DisplayId == cardDisplayID);
        if(card == null)
        {
            Console.WriteLine("ID not found");
            return;
        }
        int cardID = card.Id;
       
        
        dbService.DeleteCard(cardID);
    }
    public void CreateNewCard(int stackID)
    {
        Console.Clear();
        string front = GetString("Enter Front:");
        string back = GetString("Enter Back:");
        dbService.CreateNewCard(front, back, stackID);

    }
    public List<CardDisplayDTO> GetAllCards(int stackID, string stackName)
    {
        Console.Clear();
        var cardsList = dbService.GetAllCards(stackID);
        var displayCardsList = AppendDisplayId(cardsList);
        tableExtService.printCardsTable(displayCardsList, stackName);
        return displayCardsList;

    }
    
    public List<CardDisplayDTO> AppendDisplayId(List<CardDTO> cardsList)
    {
        int len = 1;
        List<CardDisplayDTO> displayCardsList = new();
        foreach(var card in cardsList)
        {
            displayCardsList.Add(new CardDisplayDTO(len++, card.Front, card.Back, card.Id));
        }
        return displayCardsList;
    }

    public void UpdateCard(int stackID, string stackName)
    {
        Console.Clear();
        var cardList = GetAllCards(stackID, stackName); 
        int cardDisplayID = GetInt("Enter card ID to update");
        var card = cardList.Find(card => card.DisplayId == cardDisplayID);
        if(card == null)
        {
            Console.WriteLine("ID not found");
            return;
        }
        int cardID = card.Id;
        string front = GetString("Enter Front to update");
        string back = GetString("Enter back to update");
        dbService.UpdateCard(cardID, front, back);


    }


    public bool IsCardExistsById(int cardID)
    {
        return dbService.IsRecordExistsById(cardID);
    }
}