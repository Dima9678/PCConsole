public class Precet
{
    public List<string> CommandsList { get; set; }
    public string PrecetName { get; set; }
    public string PrecetDescription { get; set; }
}
public class PrecetsHandler
{
    public readonly PrecetsOperations precetsOperations = new();
    public void PrecetLauncher(string inputCommand)
    {
        Precet precet = precetsOperations.FindPrecet(inputCommand);

        if (precet != null)
        {
            CommandHandler commandHandler = new CommandHandler();

            foreach (var command in precet.CommandsList)
            {
                commandHandler.CommandHandle(command);
            }
        }
    }
}

public class PrecetsManager
{
    private readonly ConsoleUI consoleUI = new();
    private readonly ConsoleInput consoleInput = new();
    private readonly PrecetsOperations precetsOperations = new();
    
    public void PrecetsCreator()
    {
        Precet newPrecet = new Precet();

        consoleUI.PrintMessage("Создание пресета");
        newPrecet.PrecetName = consoleInput.ReadString("Введите команду пресета");
        newPrecet.PrecetDescription = consoleInput.ReadString("Введите описание пресета");
        newPrecet.CommandsList = consoleInput.ReadCommandsList();

        precetsOperations.WriteNewPrecet(newPrecet);
    }
}

public class PrecetsOperations
{
    private readonly JsonPrecetsStorage precetsStorage = new();
    public void WriteNewPrecet(Precet newPrecet)
    {
        List<Precet> precetsList = precetsStorage.ReadPrecets();
        precetsList.Add(newPrecet);
        precetsStorage.WritePrecets(precetsList);
    }

    public Precet FindPrecet(string input)
    {
        List<Precet> precetsList = precetsStorage.ReadPrecets();

        foreach (var onePrecet in precetsList)
        {
            if (onePrecet.PrecetName == input)
            {
                return onePrecet;
            }
        }

        return null;
    }
}