using System;
using System.Collections.Generic;
using System.Text;

namespace Classes
{
    public class CommandHandler
    {
        public readonly CommandManager manager = new CommandManager();
        public readonly ConsoleUI consoleUi = new ConsoleUI();
        public void CommandHandle(string inputCommand)
        {
            JsonCommandsStorage commandsStorage = new JsonCommandsStorage();
            List<Command> commandsList = commandsStorage.ReadCommands();


            if (inputCommand == "cmnd remove")
            {
                manager.RemoveCommand();
            }
            if (inputCommand == "cmnd add")
            {
                manager.AddCommand();
            }
            if (inputCommand == "commands")
            {
                consoleUi.PrintAllComands();
            }
            else
            {
                //поиск команды в базе данных, и если она существует LaunchCommand()
            }
        }
    }
}
