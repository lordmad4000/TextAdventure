using TextAdventure.Core.Models;

namespace TextAdventure.Application.Persistence
{
    public interface IItemRepository
    {
        Task<Item> GetById(int id);
        Task<IEnumerable<Item>> GetAll();
    }
}
