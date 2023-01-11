using TextAdventure.Application.Persistence;
using TextAdventure.Core.Models;

namespace TextAdventure.Infrastructure.Repository
{
    public class AdventureRepository : IAdventureRepository
    {
        public async Task<Adventure> GetById(int id)
        {
            var items = new List<Item>();
            var characters = new List<Character>();
            var exits = new List<Exit>();
            var adventure = new Adventure(1, "Original Adventure", "Remake Atari ST Version");
            return await Task.Run(() => adventure);
        }


    }
}
