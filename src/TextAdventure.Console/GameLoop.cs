using MediatR;
using System.Text.RegularExpressions;
using TextAdventure.Application.Adventures.Dtos;
using TextAdventure.Application.Adventures.Queries.ExecuteCommand;
using TextAdventure.Application.Adventures.Queries.Start;

namespace TextAdventure
{
    public class GameLoop
    {
        private readonly IMediator _mediator;

        public GameLoop(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Run()
        {
            bool repeat = true;

            var executeCommandResult = await StartAdventure();
            PrintInConsole(executeCommandResult.TextOutput);
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
                    executeCommandResult = await ExecuteCommand(input, executeCommandResult.AdventureDto);
                    PrintInConsole(executeCommandResult.TextOutput);
                }
            } while (repeat);
        }

        static void PrintInConsole(string text)
        {
            text = text.Replace("<br>", Environment.NewLine);
            text = Regex.Replace(text, "<.*?>", string.Empty);
            Console.WriteLine(text);
        }

        private async Task<ExecuteCommandResult> StartAdventure()
        {
            var adventureDto = await _mediator.Send(new StartAdventureQuery(0));
            return new ExecuteCommandResult("", "", adventureDto);
        }

        private async Task<ExecuteCommandResult> ExecuteCommand(string input, AdventureDto adventureDto)
        {
            var executeCommandQuery = new ExecuteCommandQuery(input, "", adventureDto);
            return await _mediator.Send(executeCommandQuery);
            //return await _commandService.ExecuteCommand(new ExecuteCommandQuery(input, "", adventure));
        }

    }
}
