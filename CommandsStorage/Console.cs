using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;


public class ConsoleUI
{
    public readonly JsonCommandsStorage commandsStorage = new();
    public void PrintAllComands(bool needToEnumerate)
    {
        List<Command> commandsList = commandsStorage.ReadCommands();
        for (int i = 0; i < commandsList.Count; i++)
        {
            if (needToEnumerate) 
            {
                Console.WriteLine($"{i.ToString("D2")}. {commandsList[i].CommandName} - {commandsList[i].CommandDescription}");
            }
            else
            {
                Console.WriteLine($"{commandsList[i].CommandName} - {commandsList[i].CommandDescription}");
            }
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

public class ConsoleInput
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

    public int ReadInteger(string message)
    {
        while (true)
        {
            Console.WriteLine(message);
            string inputString = Console.ReadLine();
            if (int.TryParse(inputString, out int number))
            {
                return number;
            }
            else
            {
                Console.WriteLine("Ввод некорректен, повторите ввод");
                continue;
            }
        }
    }
    public int ReadInteger(string message, int maxValue)
    {
        while (true)
        {
            Console.WriteLine(message);
            string inputString = Console.ReadLine();
            if (int.TryParse(inputString, out int number) && number <= maxValue)
            {
                return number;
            }
            else
            {
                Console.WriteLine("Ввод некорректен, повторите ввод");
                continue;
            }
        }
    }
}
