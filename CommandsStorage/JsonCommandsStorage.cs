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