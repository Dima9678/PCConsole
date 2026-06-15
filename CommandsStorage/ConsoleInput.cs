using System;
using System.Collections.Generic;
using System.Text;

namespace Classes
{
    internal class ConsoleInput
    {
        public string ReadString(string message)
        {
            string inputString = string.Empty;
            while (true)
            {
                Console.Write(message);
                inputString = Console.ReadLine();
                if (inputString == null)
                {
                    Console.WriteLine("Ввод некорректен, повторите ввод");
                    continue;
                }
                else
                {
                    break;
                }
            }
            return inputString;
        }

        public string ReadExistingPath(string message)
        {
            string pathToExe = string.Empty;
            while (true)
            {
                Console.Write(message);
                pathToExe = Console.ReadLine();
                if (pathToExe == null || !Path.Exists(pathToExe))
                {
                    Console.WriteLine("Ввод некорректен, повторите ввод");
                    continue;
                }
                else
                {
                    break;
                }
            }
            return pathToExe;
        }

        //Когда-нибудь тут будет еще readint
    }
}
