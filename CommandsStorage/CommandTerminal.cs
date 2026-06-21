using System.Diagnostics;

public class CommandTerminal
{
    public readonly ConsoleUI consoleUi = new();
    public void ExecuteCmd(string command)
    {
        //Запуск процесса
        var process = Process.Start(new ProcessStartInfo
        {
            //Запускается cmd.exe
            FileName = "cmd.exe",
            // "/c" - выполнить команду и завершиться, command - команда
            Arguments = $"/c {command}",
            //Перенаправление потоков, вместо консоли виндоввс в мою консоль
            //вывод консоли
            RedirectStandardOutput = true,
            //Ошибки консоли
            RedirectStandardError = true,
            //отключение оболочки виндовс, чтобы она дала читать потоки
            UseShellExecute = false,
            //не открывать новое окно - true
            CreateNoWindow = true
        });

        //получение ответа консоли
        string output = process.StandardOutput.ReadToEnd();
        //получение ошибок с консоли
        string error = process.StandardError.ReadToEnd();
        //ожидание завершения
        process.WaitForExit();

        consoleUi.PrintMessage(output);

        if (!string.IsNullOrEmpty(error))
        {
            consoleUi.PrintMessage(error);
        }
    }
}
