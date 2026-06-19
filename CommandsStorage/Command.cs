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
    public void CommandHandle(string inputCommand)
    {
        List<Command> commandsList = commandsStorage.ReadCommands();

        if (inputCommand == "cmnd remove")
        {
            manager.RemoveCommand();
        }
        else if (inputCommand == "cmnd add")
        {
            manager.AddCommand();
        }
        else if (inputCommand == "commands")
        {
            consoleUi.PrintAllComands();
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

    public void AddCommand()
    {
        Command command = commandsOperations.CreateNewCommand();

        List<Command> commands = storage.ReadCommands();

        commands.Add(command);

        storage.WriteCommands(commands);

        Console.WriteLine("Команда успешно добавлена");
    }

    public void RemoveCommand()
    {
        List<Command> commandsList = storage.ReadCommands();

        for (int i = 0; i < commandsList.Count; i++)
        {
            Console.WriteLine($"{i.ToString("D2")}. {commandsList[i].CommandName} - {commandsList[i].CommandDescription}");
        }

        Console.Write("\nВведите номер команды для удаления: ");
        string commandInputNumber = Console.ReadLine();
        if (commandInputNumber != null)
        {
            int commandRemoveNumer = int.Parse(commandInputNumber);
            if (commandRemoveNumer < commandsList.Count)
            {
                commandsList.RemoveAt(commandRemoveNumer);
                Console.WriteLine("Команда успешно удалена");

                storage.WriteCommands(commandsList);
            }
            else
            {
                Console.WriteLine("Введенный индекс превышает количество команд");
            }
        }
        else
        {
            Console.WriteLine("Введенны некоректные данные");
        }
    }
}
