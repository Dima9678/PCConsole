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
    public readonly SystemController systemController = new();
    public readonly PrecetsManager precetsManager = new();
    public readonly PrecetsHandler precetsHandler = new();
    public readonly CommandTerminal commandTerminal = new();
    public bool isCmdMode = false;
    public async Task CommandHandle(string inputCommand)
    {
        if (inputCommand == "cmd")
        {
            isCmdMode = true;
        }
        else if (inputCommand == "exit")
        {
            isCmdMode = false;
        }
        else if (isCmdMode)
        {
            commandTerminal.ExecuteCmd(inputCommand);
        }
        else
        {
            if (inputCommand == Actions.Commands)
            {
                consoleUi.PrintAllComands(false);
                consoleUi.PrintIndent();
                consoleUi.PrintAllPrecets(false);
                consoleUi.PrintIndent();
                Actions.PrintActions();
            }
            else if (inputCommand == Actions.AddCommand)
            {
                manager.AddCommand();
            }
            else if (inputCommand == Actions.EditCommand)
            {
                manager.EditCommand();
            }
            else if (inputCommand == Actions.RemoveCommand)
            {
                commandsConsoleHandler.RemoveCommandMenu();
            }
            else if (inputCommand == Actions.PasswordGenerator)
            {
                passwordGenerator.GeneratePasswords(10);
            }
            else if (inputCommand == Actions.AudioOn || inputCommand == Actions.AudioOff)
            {
                systemController.AudioOutputModeChanger(inputCommand);
            }
            else if (inputCommand == Actions.DisplayOne || inputCommand == Actions.DisplayDouble)
            {
                systemController.ScreenModeChanger(inputCommand);
            }
            else if (inputCommand == Actions.Sleep)
            {
                await systemController.TurnToSleep();
            }
            else if (inputCommand == Actions.TurnOff)
            {
                systemController.PcTurnOff();
            }
            else if (Actions.IsPrecetCommand(inputCommand))
            {
                precetsHandler.PrecetLauncher(inputCommand);
            }
            else if (inputCommand == Actions.AddPrecet)
            {
                precetsManager.PrecetsCreator();
            }
            else
            {
                Command command = getCommandInfo.CommandFinder(inputCommand);
                if (command != null)
                {
                    commandsLauncher.LaunchCommand(command);
                }
                else
                {
                    consoleUi.PrintMessage("Такой команды не существует");
                }
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

        consoleUI.PrintMessage("Команда успешно добавлена");
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
    public void EditCommand()
    {
        ConsoleUI consoleUI = new();
        ConsoleInput consoleInput = new();

        List<Command> commandsList = storage.ReadCommands();
        consoleUI.PrintAllComands(true);

        int indexOfCommand = consoleInput.ReadInteger
            ("Введите номер команды для редактирования: ", 0, commandsList.Count - 1);

        consoleUI.PrintCommandFields(commandsList[indexOfCommand]);

        int indexOfField = consoleInput.ReadInteger
            ("Введите номер поля для редактирования: ", 0, 3);

        string newField = consoleInput.ReadString("Введите новое значение поля: ");

        if (indexOfField == 0)
        {
            commandsList[indexOfCommand].CommandName = newField;
        }
        else if (indexOfField == 1) 
        {
            commandsList[indexOfCommand].CommandDescription = newField;
        }
        else if (indexOfField == 2)
        {
            commandsList[indexOfCommand].Filepath = newField;
        }
        else if (indexOfField == 3)
        {
            commandsList[indexOfCommand].DirectoryPath = newField;
        }

        storage.WriteCommands(commandsList);
    }
}
