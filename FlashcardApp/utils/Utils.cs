namespace Utils;
class GetFromConsole
{
    public static int GetInt(string msg)
    {
        Console.WriteLine(msg);
        int.TryParse(Console.ReadLine(), out int res);
        return res;
    }
    public static String GetString(string msg)
    {
        Console.WriteLine(msg);
        return Console.ReadLine();
    }
  
}
