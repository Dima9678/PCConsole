using System.Text.Encodings.Web;
using System.Text.Json;
public class JsonCommandsStorage
{
    private const string JsonCommandsPath = @"Data/commands.json";

    public List<Command> ReadCommands()
    {
        string commandsFromJson = File.ReadAllText(JsonCommandsPath);
        List<Command> commandsList = JsonSerializer.Deserialize<List<Command>>(commandsFromJson)
            ?? new List<Command>();
        return commandsList;
    }
    public void AddCommand()
    {
        string pathToExe = String.Empty;
        string commandsName = String.Empty;
        string commandDescription = String.Empty;

        while (true)
        {
            Console.Write("Введите путь к запускаемому файлу: ");
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

        while (true)
        {
            Console.Write("Введите команду: ");
            commandsName = Console.ReadLine();
            if (commandsName == null)
            {
                Console.WriteLine("Ввод некорректен, повторите ввод");
                continue;
            }
            else
            {
                break;
            }
        }

        while (true)
        {
            Console.Write("Введите описание команды: ");
            commandDescription = Console.ReadLine();
            if (commandDescription == null)
            {
                Console.WriteLine("Ввод некорректен, повторите ввод");
                continue;
            }
            else
            {
                break;
            }
        }


        Command newCommand = new Command()
        {
            CommandName = commandsName,
            CommandDescription = commandDescription,
            Filepath = pathToExe,
            DirectoryPath = Directory.GetParent(pathToExe).ToString(),
        };

        List<Command> commandsList = ReadCommands();

        commandsList.Add(newCommand);

        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };
        string jsonCommands = JsonSerializer.Serialize(commandsList, options);

        File.WriteAllText(JsonCommandsPath, jsonCommands);
        Console.WriteLine("Команда успешно добавлена");
    }

    public void RemoveCommand()
    {
        string commandsFromJson = File.ReadAllText(JsonCommandsPath);
        List<Command> commandsList = ReadCommands();

        for (int i = 0; i < commandsList.Count; i++)
        {
            Console.WriteLine($"{i.ToString("D2")}. {commandsList[i].CommandName} - {commandsList[i].CommandDescription}");
        }

        Console.Write("\nВведите номер команды для удаления: ");
        string commandInputNumber = Console.ReadLine();
        if (commandInputNumber != null)
        {
            int commandRemoveNumer = int.Parse(commandInputNumber);
            if (commandRemoveNumer < commandsList.Count)
            {
                commandsList.RemoveAt(commandRemoveNumer);
                Console.WriteLine("Команда успешно удалена");

                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                };
                string jsonCommands = JsonSerializer.Serialize(commandsList, options);

                File.WriteAllText(JsonCommandsPath, jsonCommands);
            }
            else
            {
                Console.WriteLine("Введенный индекс превышает количество команд");
            }
        }
        else
        {
            Console.WriteLine("Введенны некоректные данные");
        }
    }
}
