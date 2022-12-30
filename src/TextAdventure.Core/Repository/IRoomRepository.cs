using TextAdventure.Core.Models;

namespace TextAdventure.Core.Repository
{
    public interface IRoomRepository
    {
        Task<Room> GetById(int id);
    }
}
