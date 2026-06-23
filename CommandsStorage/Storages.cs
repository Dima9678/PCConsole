using System.Text.Encodings.Web;
using System.Text.Json;
public class Storages
{
    private const string JsonCommandsPath = @"Data/commands.json";

    public List<Command> ReadCommands()
    {
        string commandsFromJson = File.ReadAllText(JsonCommandsPath);
        List<Command> commandsList = JsonSerializer.Deserialize<List<Command>>(commandsFromJson)
            ?? new List<Command>();
        return commandsList;
    }
    public void WriteCommands(List<Command> commands)
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };
        string jsonCommands = JsonSerializer.Serialize(commands, options);

        File.WriteAllText(JsonCommandsPath, jsonCommands);
    }
}

public class JsonPrecetsStorage
{
    private readonly string presetsJsonPath = @"Data/precets.json";

    public List<Precet> ReadPrecets()
    {
        string precetsFromJson = File.ReadAllText(presetsJsonPath);
        List<Precet> precetsList = JsonSerializer.Deserialize<List<Precet>>(precetsFromJson)
            ?? new List<Precet>();
        return precetsList;
    }
    public void WritePrecets(List<Precet> precets)
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };
        string jsonPrecets = JsonSerializer.Serialize(precets, options);

        File.WriteAllText(presetsJsonPath, jsonPrecets);
    }
}

public class DirectoriesStorage
{
    public readonly string directoriesJsonPath = @"Data/Directories.json";
    public List<Directories> ReadDirectories()
    {
        string commandsFromJson = File.ReadAllText(directoriesJsonPath);
        List<Directories> directoriesList = JsonSerializer.Deserialize<List<Directories>>(commandsFromJson)
            ?? new List<Directories>();
        return directoriesList;
    }
    public void WriteDIrectories(List<Directories> directories)
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };
        string jsonDirectories = JsonSerializer.Serialize(directories, options);

        File.WriteAllText(directoriesJsonPath, jsonDirectories);
    }
}