using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace CommandsStorage
{
    public class ApplicationLauncher
    {
        public void LaunchCommand(string inputCommand)
        {
            JsonCommandsStorage commandsStorage = new JsonCommandsStorage();
            List<Command> commandsList = commandsStorage.ReadCommands();

            for (int i = 0; i < commandsList.Count; i++)
            {
                if (commandsList[i].CommandName == inputCommand)
                {
                    Process.Start(commandsList[i].Filepath, commandsList[i].DirectoryPath);
                    break;
                }
                if (i == commandsList.Count - 1)
                {
                    Console.WriteLine("Неизвестная команда");
                }
            }
        }
    }
}
