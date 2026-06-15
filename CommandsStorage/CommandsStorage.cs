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
    public void AddCommand(string pathToExe, string commandsName, string commandDescription)
    {
        Command newCommand = new Command() 
        {
            CommandName = commandsName,
            CommandDescription = commandDescription,
            Filepath = pathToExe,
            DirectoryPath = Path.GetPathRoot(pathToExe),
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
