using ConsoleTableExt;
internal class TableExt
{
    public void printStackTable(List<Stack> tableData)
    {
        ConsoleTableBuilder
        .From(tableData)
        .WithTitle("STACKS ", ConsoleColor.Yellow, ConsoleColor.DarkGray)
        .WithColumn("Id", "Name")
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

    public void printCardsTable(List<CardDisplayDTO> tableData, string stackName)
    {
        List<CardDTO> cardList = new();
        foreach(var card in tableData)
        {
            cardList.Add(new CardDTO(card.DisplayId, card.Front, card.Back));
        }
        ConsoleTableBuilder
        .From(cardList)
        .WithTitle(stackName.ToUpper(), ConsoleColor.Yellow, ConsoleColor.DarkGray)
        .WithColumn("Id", "Front", "Back")
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