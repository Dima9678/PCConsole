using Classes;

public class Program
{
    public static readonly CommandHandler handler = new();
    public static readonly PreStart preStartClasses = new();
    static void Main(string[] args)
    {
        preStartClasses.PreStartActions();
        Console.WriteLine("To see comand list print commands");
        while (true) 
        {
            if (handler.isCmdMode)
            {
                Console.Write("cmd mode");
            }
            Console.Write("//");
            string inputCommand = Console.ReadLine();
            handler.CommandHandle(inputCommand);
            Console.WriteLine("");
        }
    }
}