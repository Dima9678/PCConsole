public class PasswordGenerator
{
    private readonly PasswordsConsoleUI consoleUI = new();
    private readonly ConsoleInput consoleInput = new();
    public void GeneratePasswords(int countOfPasswords)
    {
        consoleUI.PrintPasswordsDifficulties();
        int passwordDifficulty = consoleInput.ReadInteger("Выберите сложность пароля: ",4);

        for (int i = 0; i < countOfPasswords; i++)
        {
            string password = Generate(passwordDifficulty);
            consoleUI.PrintPassword(password);
        }
    }

    private string Generate(int difficutly)
    {
        Random rnd = new();
        string password = string.Empty;
        string avaiabeSymbols = string.Empty;

        string[] symbols = 
        {
            //Цифры
            "0123456789012345678901234567890123456789",
            //Английские маленькие буквы
            "qwertyuioplkjhgfdsazxcvbnm",
            //Английские большие буквы
            "QWERTYUIOPLKJHGFDSAZXCVBNM",
            //символы ! # $ % & * +
            "!#$%&*+",
        };

        for (int i = 0; i < difficutly; i++)
        {
            avaiabeSymbols += symbols[i];
        }

        for (int i = 0; i < 10; i++)
        {
            password += avaiabeSymbols[rnd.Next(0,avaiabeSymbols.Length)];
        }

        return password;
    }
}

public class PasswordsConsoleUI
{
    private string message = """
        Сложность пароля:
        1 -- 1-8
        2 -- 1-8, a-z
        3 -- 1-8, a-z, A-Z
        4 -- 1-8, a-z, A-Z, символы(! # $ % & * +)
        """;

    public void PrintPasswordsDifficulties() 
    {
        Console.WriteLine(message);
    }
    public void PrintPassword(string password)
    {
        Console.WriteLine(password);
    }
}
