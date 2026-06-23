using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;


public class ConsoleUI
{
    public readonly Storages commandsStorage = new();
    public readonly JsonPrecetsStorage precetsStorage = new();
    public void PrintAllComands(bool needToEnumerate)
    {
        PrintMessage("Команды: ");
        List<Command> commandsList = commandsStorage.ReadCommands();
        for (int i = 0; i < commandsList.Count; i++)
        {
            if (needToEnumerate) 
            {
                PrintMessage($"{i}. {commandsList[i].CommandName} - {commandsList[i].CommandDescription}");
            }
            else
            {
                PrintMessage($"{commandsList[i].CommandName} - {commandsList[i].CommandDescription}");
            }
        }
    }
    public void PrintAllPrecets(bool needToEnumerate)
    {
        PrintMessage("Пресеты: ");
        List<Precet> precetsList = precetsStorage.ReadPrecets();
        for (int i = 0; i < precetsList.Count; i++)
        {
            if (needToEnumerate)
            {
                PrintMessage($"{i.ToString("D2")}. {precetsList[i].PrecetName} - {precetsList[i].PrecetDescription}");
            }
            else
            {
                PrintMessage($"{precetsList[i].PrecetName} - {precetsList[i].PrecetDescription}");
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
    public void PrintIndent()
    {
        Console.WriteLine("");
    }
    public void PrintMessage(string message)
    {
        Console.WriteLine(message);
    }
    public void PrintCommandFields(Command command)
    {
        Console.WriteLine($"""
            0. Команда: {command.CommandName}
            1. Описание команды: {command.CommandDescription}
            2. Путь к запускаемому файлу: {command.Filepath}
            3. Путь к родительской директории файла: {command.DirectoryPath}
            """);
    }
}

public class ConsoleInput
{
    private readonly ConsoleUI consoleUI = new();
    public string ReadString(string message)
    {
        string inputString = string.Empty;
        while (true)
        {
            consoleUI.PrintMessage(message);
            inputString = Console.ReadLine();
            if (inputString == null)
            {
                consoleUI.PrintMessage("Ввод некорректен, повторите ввод");
                continue;
            }
            if (inputString == "null")
            {
                inputString = null;
                break;
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
            consoleUI.PrintMessage(message);
            pathToExe = Console.ReadLine();
            if (pathToExe == null || !Path.Exists(pathToExe))
            {
                consoleUI.PrintMessage("Ввод некорректен, повторите ввод");
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
            consoleUI.PrintMessage(message);
            string inputString = Console.ReadLine();
            if (int.TryParse(inputString, out int number))
            {
                return number;
            }
            else
            {
                consoleUI.PrintMessage("Ввод некорректен, повторите ввод");
                continue;
            }
        }
    }
    public int ReadInteger(string message, int minValue, int maxValue)
    {
        while (true)
        {
            consoleUI.PrintMessage(message);
            string inputString = Console.ReadLine();
            if (int.TryParse(inputString, out int number))
            {
                if (number < minValue || number > maxValue)
                {
                    consoleUI.PrintMessage("Число выходит за границы допустимого ввода");
                    continue;
                }
                return number;
            }
            else
            {
                consoleUI.PrintMessage("Ввод некорректен, повторите ввод");
                continue;
            }
        }
    }
    public TimeOnly ReadTime(string message)
    {
        while (true)
        {
            consoleUI.PrintMessage(message);
            string inputString = Console.ReadLine();
            if (TimeOnly.TryParse(inputString, out TimeOnly timeOnly))
            {
                return timeOnly;
            }
            else
            {
                consoleUI.PrintMessage("Ввод некорректен, повторите ввод");
                continue;
            }
        }
    }
    public List<string> ReadCommandsList()
    {
        List<string> presets = new List<string>();

        while (true) 
        {
            consoleUI.PrintMessage("Ввеите название команы или 0 для завершения добавления");

            string input = Console.ReadLine();

            if (!string.IsNullOrEmpty(input))
            {
                if (input == "0")
                {
                    return presets;
                }
                else
                {
                    presets.Add(input);
                }
            }
            else
            {
                consoleUI.PrintMessage("Некорректный ввод");
            }
        }

        return presets;
    }
}
