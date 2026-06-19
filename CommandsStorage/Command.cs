using Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
public class Command
{
    public string CommandName { get; set; }
    public string CommandDescription { get; set; }
    public string Filepath { get; set; }
    public string DirectoryPath { get; set; }
}

public class CommandsLauncher
{
    public void LaunchCommand(Command command)
    {
        Process.Start(command.Filepath, command.DirectoryPath);
    }
}

public class CommandHandler
{
    public readonly CommandManager manager = new();
    public readonly CommandsOperations getCommandInfo = new();
    public readonly CommandsLauncher commandsLauncher = new();
    public readonly ConsoleUI consoleUi = new ConsoleUI();
    public readonly JsonCommandsStorage commandsStorage = new();
    public readonly CommandsConsoleHandler commandsConsoleHandler = new();
    public readonly PasswordGenerator passwordGenerator = new();
    public void CommandHandle(string inputCommand)
    {
        List<Command> commandsList = commandsStorage.ReadCommands();

        if (inputCommand == "cmnd remove")
        {
            commandsConsoleHandler.RemoveCommandMenu();
        }
        else if (inputCommand == "cmnd add")
        {
            manager.AddCommand();
        }
        else if (inputCommand == "commands")
        {
            consoleUi.PrintAllComands(false);
        }
        else if (inputCommand == "pwg")
        {
            passwordGenerator.GeneratePasswords(10);
        }
        else
        {
            Command command = getCommandInfo.CommandFinder(inputCommand);
            if (command != null)
            {
                commandsLauncher.LaunchCommand(command);
            }
        }
    }
}

public class CommandManager
{
    private readonly JsonCommandsStorage storage = new();
    private readonly CommandsOperations commandsOperations = new();
    private readonly ConsoleInput consoleInput = new();
    private readonly ConsoleUI consoleUI = new();

    public void AddCommand()
    {
        Command command = commandsOperations.CreateNewCommand();
        List<Command> commands = storage.ReadCommands();

        commands.Add(command);
        storage.WriteCommands(commands);

        Console.WriteLine("Команда успешно добавлена");
    }
    public bool RemoveCommand(int index)
    {
        List<Command> commandsList = storage.ReadCommands();

        if (index < 0 || index >= commandsList.Count)
            return false;

        commandsList.RemoveAt(index);
        storage.WriteCommands(commandsList);

        return true;
    }
}
