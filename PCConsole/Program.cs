using Classes;
using CommandsStorage;

internal class Program
{
    static void Main(string[] args)
    {
        CommandHandler handler = new CommandHandler();
        Console.WriteLine("To see comand list print commands");
        while (true) 
        {
            Console.Write("//");
            string inputCommand = Console.ReadLine();
            handler.LaunchCommand(inputCommand);
            Console.WriteLine("");
        }
    }
}