using CommandsStorage;

internal class Program
{
    static void Main(string[] args)
    {
        ApplicationLauncher applicationLauncher = new ApplicationLauncher();
        Console.WriteLine("To see comand list print commands");
        while (true) 
        {
            Console.Write("//");
            //string inputCommand = Console.ReadLine();
            string inputCommand = "cmnd add";
            applicationLauncher.LaunchCommand(inputCommand);
            Console.WriteLine("");
        }
    }
}