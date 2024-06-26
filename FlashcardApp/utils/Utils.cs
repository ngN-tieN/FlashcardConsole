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
        return Console.ReadLine().Trim().ToLower();
    }
  
}
class Wait
{
    public static void WaitForExit()
    {
        bool tag = true;
        while (tag == true)
        {
            Console.WriteLine("Enter 0 to return");
            if (Console.ReadLine().Equals("0"))
            {
                tag = false;
            }
        }
    }
}
static class RandomShuffle
{
    public static void Shuffle<T>(this IList<T> list)  
    {  
        Random rng = new();
        int n = list.Count;  
        while (n > 1)
        {  
            n--;  
            int k = rng.Next(n + 1);  
            T value = list[k];  
            list[k] = list[n];  
            list[n] = value;  
        }  
    }
}