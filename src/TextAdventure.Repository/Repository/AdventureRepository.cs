using TextAdventure.Core.Interfaces;
using TextAdventure.Core.Models;

namespace TextAdventure.Repository.Repository
{
    public class AdventureRepository : IAdventureRepository
    {
        public async Task<Adventure> GetById(int id)
        {
            var room = new Room(0, 
                                "Start", 
                                @"You are just in the border between the North badlands and the wet forests of the South. Close
                                to you, to the East, you can see a brick cabin surrounded by a thick grove. A stream flows South.");
            var items = new List<Item>();
            var characters = new List<Character>();
            var exits = new List<Exit>();
            var adventure = new Adventure(1, 
                                          "Original Adventure", 
                                          "Remake Atari ST Version", 
                                          room, 
                                          items, 
                                          characters,
                                          exits);
            return await Task.Run(() => adventure);
        }
    }
}
