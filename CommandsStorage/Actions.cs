public static class Actions
{
    public const string Commands = "commands";

    public const string AddCommand = "cmnd add";
    public const string RemoveCommand = "cmnd remove";

    public const string AddPrecet = "p add";

    public const string PasswordGenerator = "pwg";

    public const string Sleep = "sleep";
    public const string TurnOff = "off";

    public const string AudioOn = "sdon";
    public const string AudioOff = "sdof";

    public const string DisplayOne = "do";
    public const string DisplayDouble = "db";

    public static bool IsPrecetCommand(string inputCommand)
    {
        if(inputCommand[0] == 'p' && inputCommand.Length == 4)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
