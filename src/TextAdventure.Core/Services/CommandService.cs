using TextAdventure.Core.Repository;
using TextAdventure.Core.Models;

namespace TextAdventure.Core.Services
{
    public class CommandService : ICommandService
    {
        private readonly IAdventureRepository _adventureRepository;

        public CommandService(IAdventureRepository adventureRepository)
        {
            _adventureRepository = adventureRepository;
        }

        public async Task<CommandResult> ExecuteCommand(Command command)
        {
            var adventure = await _adventureRepository.GetById(0);
            var commandResult = new CommandResult(command.TextInput, adventure.ActualRoom.Description, adventure);

            return commandResult;
        }
    }
}
