using ConsoleTableExt;
namespace Utils;
class TableExt
{
    public static void printStackTable(List<Stack> stacksList)
    {
        printTable(stacksList, "Stacks", "Id", "Name");
    }

    public static void printCardsTable(List<CardDisplayDTO> cardsWithDatabaseIdList, string stackName)
    {
        List<CardDTO> cardsList = new();
        foreach(var card in cardsWithDatabaseIdList)
        {
            cardsList.Add(new CardDTO(card.DisplayId, card.Front, card.Back));
        }
        printTable(cardsList, stackName, "ID", "Front", "Back");
    }
    public static void printQuizTable(string cardFront, string stackName)
    {
        List<QuizDTO> tableData = [new QuizDTO(cardFront)];
        printTable(tableData, stackName, "Front");
    }
    
    public static void printTable<T>(List<T> tableData, string tableName, params string[] columns) where T:class
    {
        ConsoleTableBuilder
        .From(tableData)
        .WithTitle(tableName.ToUpper(), ConsoleColor.Yellow, ConsoleColor.DarkGray)
        .WithColumn(columns)
        .WithMinLength(new Dictionary<int, int> {
            { 1, 5 },
            { 2, 5 }
        })
        .WithTextAlignment(new Dictionary<int, TextAligntment>
        {
            {2, TextAligntment.Right }
        })
        .WithCharMapDefinition(new Dictionary<CharMapPositions, char> {
            {CharMapPositions.BottomLeft, '=' },
            {CharMapPositions.BottomCenter, '=' },
            {CharMapPositions.BottomRight, '=' },
            {CharMapPositions.BorderTop, '=' },
            {CharMapPositions.BorderBottom, '=' },
            {CharMapPositions.BorderLeft, '|' },
            {CharMapPositions.BorderRight, '|' },
            {CharMapPositions.DividerY, '|' },
        })
        .WithHeaderCharMapDefinition(new Dictionary<HeaderCharMapPositions, char> {
            {HeaderCharMapPositions.TopLeft, '=' },
            {HeaderCharMapPositions.TopCenter, '=' },
            {HeaderCharMapPositions.TopRight, '=' },
            {HeaderCharMapPositions.BottomLeft, '|' },
            {HeaderCharMapPositions.BottomCenter, '-' },
            {HeaderCharMapPositions.BottomRight, '|' },
            {HeaderCharMapPositions.Divider, '|' },
            {HeaderCharMapPositions.BorderTop, '=' },
            {HeaderCharMapPositions.BorderBottom, '-' },
            {HeaderCharMapPositions.BorderLeft, '|' },
            {HeaderCharMapPositions.BorderRight, '|' },
        })
        .ExportAndWriteLine(TableAligntment.Left);
    
    }
}