public static class Actions
{
    public const string Commands = "commands";
    public const string AddCommand = "cmnd add";
    public const string EditCommand = "cmnd ed";
    public const string RemoveCommand = "cmnd remove";
    public const string AddPrecet = "p add";
    public const string PasswordGenerator = "pwg";
    public const string Sleep = "sleep";
    public const string TurnOff = "off";
    public const string AudioOn = "sdon";
    public const string AudioOff = "sdof";
    public const string DisplayOne = "do";
    public const string DisplayDouble = "db";

    public static readonly Dictionary<string, string> ActionsDescription = new()
    {
        {Commands, "Вывод всех команд на консоль"},
        {AddCommand ,"Добавление команды"},
        {EditCommand ,"Редактирование команды"},
        {RemoveCommand ,"Удаление команды"},
        {AddPrecet ,"Добавление пресета"},
        {PasswordGenerator ,"Генератор паролей"},
        {Sleep ,"Отправить пк спать до определенного времени"},
        {TurnOff ,"Выключение пк"},
        {AudioOn ,"Переключение звука на динамики"},
        {AudioOff ,"Переключение звука на монитор"},
        {DisplayOne ,"Работать будет один монитор"},
        {DisplayDouble ,"Включение обоих мониторов"}
    };

    public static bool IsPrecetCommand(string inputCommand)
    {
        if (inputCommand[0] == 'p' && inputCommand.Length == 4)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static void PrintActions()
    {
        ConsoleUI consoleUI = new ConsoleUI();
        consoleUI.PrintMessage("Список действий: ");
        foreach (var action in ActionsDescription)
        {
            consoleUI.PrintMessage($"{action.Key} - {action.Value}");
        }
    }
}
