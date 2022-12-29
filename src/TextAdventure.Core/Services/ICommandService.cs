using TextAdventure.Core.Models;

namespace TextAdventure.Core.Services
{
    public interface ICommandService
    {
        Task<CommandResult> ExecuteCommand(Command command);
    }
}