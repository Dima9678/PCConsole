using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Classes
{
    //Запуск команд
    public class CommandsLauncher
    {
        public void LaunchCommand(Command command)
        {
            Process.Start(command.Filepath, command.DirectoryPath);
        }
    }
}
