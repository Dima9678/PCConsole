using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Classes
{
    public  class ConsoleUI
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
    }
}
