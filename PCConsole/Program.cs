using Classes;

public class Program
{
    public static readonly CommandHandler handler = new();
    public static readonly PreStartClasses preStartClasses = new();
    static void Main(string[] args)
    {
        preStartClasses.PreStartActions();
        Console.WriteLine("To see comand list print commands");
        while (true) 
        {
            Console.Write("//");
            string inputCommand = Console.ReadLine();
            handler.CommandHandle(inputCommand);
            Console.WriteLine("");
        }
    }
}