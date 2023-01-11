using TextAdventure.Core.Models;

namespace TextAdventure.Application.Persistence
{
    public interface IAdventureRepository
    {
        Task<Adventure> GetById(int id);
    }
}
