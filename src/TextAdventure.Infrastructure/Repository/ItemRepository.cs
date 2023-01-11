using TextAdventure.Application.Persistence;
using TextAdventure.Core.Exceptions;
using TextAdventure.Core.Models;

namespace TextAdventure.Infrastructure.Repository
{
    public class ItemRepository : IItemRepository
    {
        public async Task<Item> GetById(int id)
        {
            var item = GetItems().FirstOrDefault(x => x.Id == id);
            if (item is null)
                throw new ItemNotFoundException($"Item with Id {id} not found.");

            return await Task.Run(() => item);
        }

        public async Task<IEnumerable<Item>> GetAll()
        {
            return await Task.Run(() => GetItems());
        }

        private List<Item> GetItems()
        {
            var items = new List<Item>()
            {
                new Item(0, "Table", "", "", "", "Rustic and made of good wood. Used by the Dwarves of the Forest.", "Start"),
                new Item(1, "Chair", "Chairs", "", "", "Rustic and made of good wood. Used by the Dwarves of the Forest.", "Start"),
                new Item(2, "Tree", "Trees", "Forest", "", "You are not learning botanics.", "Start"),
                new Item(3, "Water", "Stream", "River", "", "It is said that this river has the magical power of making old seeds to grow.", "Start"),
                new Item(3, "Cabin", "House", "", "", "This solid building once belonged to the owners of the Valley. Today it is abandoned.", "Start"),
                new Item(4, "Door", "", "", "", "An old oak door.", "Start"),
                new Item(5, "Battery", "", "", "", "It looks like to be in good condition.", "Start")
            };

            return items;
        }

    }
}
