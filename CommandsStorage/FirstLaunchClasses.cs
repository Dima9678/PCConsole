using System;
using System.Collections.Generic;
using System.Text;
//Классы, которые работают перед запуском основного цикла
//Очистка рабочего стола
namespace Classes
{
    public class PreStartClasses
    {
        public readonly DesktopCleaner desktopCleaner = new();
        public readonly WorkdayCalculator workdayCalculator = new();
        public readonly SystemController systemController = new();

        public void PreStartActions()
        {
            bool isWorkDay = workdayCalculator.Calculate();
            if (isWorkDay)
            {
                systemController.AudioOutputModeChanger("sdof");
                systemController.ScreenModeChanger("do");
            }
            else
            {
                systemController.AudioOutputModeChanger("sdon");
                systemController.ScreenModeChanger("db");
            }
            desktopCleaner.Clean();
        }
    }

    public class DesktopCleaner
    {
        public readonly ConsoleUI consoleUI = new();

        public readonly string DesktopPath = @"C:\Users\dima\Desktop";
        public readonly string TargetPath = @"S:\Desktop";

        public string[] FilesOnDesktop;
        public List<string> MovedFiles = new();

        public void Clean() 
        {
            int movedCount = 0;
            FilesOnDesktop = Directory.GetFiles(DesktopPath);
            //Не факт, что 
            for (int i = 0; i < FilesOnDesktop.Length; i++)
            {
                if (Path.GetExtension(FilesOnDesktop[i]) != ".ini")
                {
                    string filename = Path.GetFileName(FilesOnDesktop[i]);
                    string newPath = Path.Combine(TargetPath, filename);
                    File.Move(FilesOnDesktop[i], newPath, true);
                    movedCount++;
                    MovedFiles.Add(FilesOnDesktop[i]);
                }
            }
            consoleUI.PrintMovedFilesCount(MovedFiles);
        }
    }
}
