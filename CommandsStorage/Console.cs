using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;


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

internal class ConsoleInput
{
    public string ReadString(string message)
    {
        string inputString = string.Empty;
        while (true)
        {
            Console.Write(message);
            inputString = Console.ReadLine();
            if (inputString == null)
            {
                Console.WriteLine("Ввод некорректен, повторите ввод");
                continue;
            }
            else
            {
                break;
            }
        }
        return inputString;
    }

    public string ReadExistingPath(string message)
    {
        string pathToExe = string.Empty;
        while (true)
        {
            Console.Write(message);
            pathToExe = Console.ReadLine();
            if (pathToExe == null || !Path.Exists(pathToExe))
            {
                Console.WriteLine("Ввод некорректен, повторите ввод");
                continue;
            }
            else
            {
                break;
            }
        }
        return pathToExe;
    }

    //Когда-нибудь тут будет еще readint
}
