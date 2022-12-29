using TextAdventure.Core.Models;

namespace TextAdventure.Core.Repository
{
    public interface IAdventureRepository
    {
        Task<Adventure> GetById(int id);
    }
}
