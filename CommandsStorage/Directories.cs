
using System.Diagnostics;
using System.Text.Encodings.Web;
using System.Text.Json;
public class Directories
{
    public string DirectoryCommand { get; set; }
    public string DirectoryPath { get; set; }
}

public class DirectoriesOperations
{
    private readonly ConsoleUI consoleUI = new();
    public readonly ConsoleInput consoleInput= new();
    private readonly DirectoriesStorage storage = new();
    public bool IsDirectoryCommand(string command) 
    {
        if (command[0] == 'd' && command[1] == ' ')
        {
            return true;
        }
        return false;
    }
    public void DirectoryHandler(string command)
    {
        Directories directory = DirectoriesFinder(command);
        if (directory != null)
        {
            DirectoriesLauncher(directory);
        }
        else
        {
            consoleUI.PrintMessage("Такой команды не существует");
        }
    }
    public Directories DirectoriesFinder(string command)
    {
        List<Directories> directories = storage.ReadDirectories();

        foreach (Directories directory in directories) 
        {
            if (directory.DirectoryCommand == command)
            {
                return directory;
            }
        }
        return null;
    }
    public void DirectoriesLauncher(Directories directory)
    {
        Process.Start("explorer.exe", directory.DirectoryPath);
    }

    public void AddDirectory()
    {
        Directories directory = new();
        directory.DirectoryPath = consoleInput.ReadExistingPath("Введите адрес директории: ");
        directory.DirectoryCommand = consoleInput.ReadString("Введите команду для вызова директории: ");

        List<Directories> directories = new();
        directories = storage.ReadDirectories();
        directories.Add(directory);
        storage.WriteDIrectories(directories);
    }
}