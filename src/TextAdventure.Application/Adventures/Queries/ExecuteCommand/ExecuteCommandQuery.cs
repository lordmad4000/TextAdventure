using MediatR;
using TextAdventure.Application.Adventures.Dtos;

namespace TextAdventure.Application.Adventures.Queries.ExecuteCommand
{
    public class ExecuteCommandQuery : IRequest<ExecuteCommandResult>
    {
        public ExecuteCommandQuery(string textCommand, string textOutput, AdventureDto adventureDto)
        {
            TextCommand = textCommand;
            TextOutput = textOutput;
            AdventureDto = adventureDto;
        }

        public string TextCommand { get; }
        public string TextOutput { get; }
        public AdventureDto AdventureDto { get; }

    }
}
