using TextAdventure.Core.Models;

namespace TextAdventure.Application.Persistence
{
    public interface ICharacterRepository
    {
        Task<Character> GetById(int id);
        Task<IEnumerable<Character>> GetAll();
    }
}
