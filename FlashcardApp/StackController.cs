using Microsoft.VisualBasic;

internal class StackController
{
    private MSSQLDatabase dbService = new();
    private TableExt tableExtService = new();
    public void GetAllStacks()
    {
        string commandInput = "SELECT * FROM STACKS";
        var stacks = dbService.TDapperGetAllStack(commandInput);
        tableExtService.printStackTable(stacks);
    }
}