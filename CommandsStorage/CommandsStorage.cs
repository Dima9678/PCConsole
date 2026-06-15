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

        string commandsFromJson = File.ReadAllText(JsonCommandsPath);
        List<Command> commandsList = JsonSerializer.Deserialize<List<Command>>(commandsFromJson)
            ?? new List<Command>();

        commandsList.Add(newCommand);

        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };
        string jsonCommands = JsonSerializer.Serialize(commandsList, options);

        File.WriteAllText(JsonCommandsPath, jsonCommands);
    }
}
