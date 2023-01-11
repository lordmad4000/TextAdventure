using TextAdventure.Core.Models;

namespace TextAdventure.Application.Persistence
{
    public interface IRoomRepository
    {
        Task<Room> GetByName(string name);
        Task<Room> GetById(int id);
    }
}
