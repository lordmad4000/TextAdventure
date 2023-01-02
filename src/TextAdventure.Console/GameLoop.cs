using System.Text.RegularExpressions;
using TextAdventure.Core.Models;
using TextAdventure.Core.Services;

namespace TextAdventure
{
    public class GameLoop
    {
        private readonly ICommandService _commandService;

        public GameLoop(ICommandService commandService)
        {
            _commandService = commandService;
        }
        
        public async Task Run()
        {
            bool repeat = true;

            var resultCommand = await StartAdventure();
            PrintInConsole(resultCommand.TextOutput);
            do
            {
                var input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                    input = "";
                if (input.ToLower() == "exit")
                {
                    Console.WriteLine(@"Exit? Press 'Y' to confirm");
                    ConsoleKeyInfo readKey = Console.ReadKey();
                    if (readKey.Key == ConsoleKey.Y)
                        repeat = false;
                }
                else
                {
                    resultCommand = await ExecuteCommand(input, resultCommand.Adventure);
                    PrintInConsole(resultCommand.TextOutput);
                }
            } while (repeat);
        }

        static void PrintInConsole(string text)
        {
            text = text.Replace("<br>", Environment.NewLine);
            text = Regex.Replace(text, "<.*?>", string.Empty);
            Console.WriteLine(text);
        }

        private async Task<ResultCommand> StartAdventure()
        {
            return await _commandService.ExecuteCommand(new Command("start", "", new Adventure()));
        }

        private async Task<ResultCommand> ExecuteCommand(string input, Adventure adventure)
        {
            return await _commandService.ExecuteCommand(new Command(input, "", adventure));
        }

    }
}
