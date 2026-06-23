using System;
using System.Collections.Generic;
using System.Text;

namespace Classes
{
    //Класс 
    public class CommandsOperations
    {
        private readonly ConsoleInput consoleInput = new();
        private readonly Storages commandsStorage = new();
        public Command CreateNewCommand()
        {
            string pathToExe = consoleInput.ReadExistingPath("Введите путь к файлу: ");
            string commandsName = consoleInput.ReadString("Введите команду: ");
            string commandDescription = consoleInput.ReadString("Введите описание команды: ");

            return new Command
            {
                Filepath = pathToExe,
                CommandName = commandsName,
                CommandDescription = commandDescription
            };
        }
        //Ищет команду в списке команд. Если найдена, возвращает команду, если нет, возвращает null
        public Command CommandFinder(string command)
        {
            List<Command> commandsList = commandsStorage.ReadCommands();
            Command? findedCommand = null;

            foreach (var command1 in commandsList)
            {
                if (command1.CommandName == command)
                {
                    findedCommand = command1;
                    break;
                }
            }

            return findedCommand;
        }
    }
}
