using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Classes
{
    public class ConsoleUI
    {
        public readonly JsonCommandsStorage commandsStorage = new();
        public void PrintAllComands()
        {
            List<Command> commandsList = commandsStorage.ReadCommands();
            for (int i = 0; i < commandsList.Count; i++)
            {
                Console.WriteLine($"{commandsList[i].CommandName} - {commandsList[i].CommandDescription}");
            }
        }
        public void PrintMovedFilesCount(List<string> movedFiles)
        {
            if (movedFiles.Count > 0)
            {
                Console.WriteLine($"Было перемещено {movedFiles.Count} файлов:");
                foreach (var name in movedFiles)
                {
                    Console.WriteLine(name);
                }
                Console.WriteLine("");
            }
        }
    }
}
