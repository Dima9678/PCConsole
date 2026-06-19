public class CommandsConsoleHandler
{
    private readonly ConsoleUI consoleUI = new();
    private readonly ConsoleInput consoleInput = new();
    public readonly CommandManager commandManager = new();
    public void RemoveCommandMenu()
    {
        consoleUI.PrintAllComands(true);

        int commandIndex = consoleInput.ReadInteger("\nВведите номер команды для удаления: ");
        bool operationResult = commandManager.RemoveCommand(commandIndex);
        if (operationResult) 
        {
            Console.WriteLine("Команда успешно удалена");
        }
        else
        {
            Console.WriteLine("Ошибка при удалении команды");
        }
    }
}
