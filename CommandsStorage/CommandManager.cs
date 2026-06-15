using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace Classes
{
    public class CommandManager
    {
        private readonly JsonCommandsStorage storage = new();
        private readonly GetCommandInfo commandInfo = new();

        public void AddCommand()
        {
            Command command = commandInfo.GetNewCommand();

            List<Command> commands = storage.ReadCommands();

            commands.Add(command);

            storage.WriteCommands(commands);

            Console.WriteLine("Команда успешно добавлена");
        }

        public void RemoveCommand()
        {
            List<Command> commandsList = storage.ReadCommands();

            for (int i = 0; i < commandsList.Count; i++)
            {
                Console.WriteLine($"{i.ToString("D2")}. {commandsList[i].CommandName} - {commandsList[i].CommandDescription}");
            }

            Console.Write("\nВведите номер команды для удаления: ");
            string commandInputNumber = Console.ReadLine();
            if (commandInputNumber != null)
            {
                int commandRemoveNumer = int.Parse(commandInputNumber);
                if (commandRemoveNumer < commandsList.Count)
                {
                    commandsList.RemoveAt(commandRemoveNumer);
                    Console.WriteLine("Команда успешно удалена");

                    storage.WriteCommands(commandsList);
                }
                else
                {
                    Console.WriteLine("Введенный индекс превышает количество команд");
                }
            }
            else
            {
                Console.WriteLine("Введенны некоректные данные");
            }
        }
    }
}