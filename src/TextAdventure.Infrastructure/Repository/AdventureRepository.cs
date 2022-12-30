using TextAdventure.Core.Repository;
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
            var adventure = new Adventure(1, 
                                          "Original Adventure", 
                                          "Remake Atari ST Version", 
                                          new Room(0, "","",new List<Exit>()), 
                                          items, 
                                          characters,
                                          exits);
            return await Task.Run(() => adventure);
        }


    }
}
