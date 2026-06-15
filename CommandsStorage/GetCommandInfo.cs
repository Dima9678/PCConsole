using System;
using System.Collections.Generic;
using System.Text;

namespace Classes
{
    //Класс 
    public class GetCommandInfo
    {
        private readonly ConsoleInput consoleInput = new();
        public Command GetNewCommand()
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
    }
}
