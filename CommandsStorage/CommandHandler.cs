using System;
using System.Collections.Generic;
using System.Text;

namespace Classes
{
    public class CommandHandler
    {
        public readonly CommandManager manager = new CommandManager();
        public readonly GetCommandInfo getCommandInfo = new GetCommandInfo();
        public readonly CommandsLauncher commandsLauncher = new CommandsLauncher();
        public readonly ConsoleUI consoleUi = new ConsoleUI();
        public void CommandHandle(string inputCommand)
        {
            JsonCommandsStorage commandsStorage = new JsonCommandsStorage();
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
}
