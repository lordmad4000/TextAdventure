using TextAdventure.Core.Models;

namespace TextAdventure.Core.Services
{
    public interface ICommandService
    {
        Task<Command> ExecuteCommand(Command command);
    }
}