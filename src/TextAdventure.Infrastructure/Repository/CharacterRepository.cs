using TextAdventure.Application.Persistence;
using TextAdventure.Core.Exceptions;
using TextAdventure.Core.Models;

namespace TextAdventure.Infrastructure.Repository
{
    public class CharacterRepository : ICharacterRepository
    {
        public async Task<Character> GetById(int id)
        {
            var character = GetCharacters().FirstOrDefault(x => x.Id == id);
            if (character is null)
                throw new CharacterNotFoundException($"Character with Id {id} not found.");

            return await Task.Run(() => character);
        }

        public async Task<IEnumerable<Character>> GetAll()
        {
            return await Task.Run(() => GetCharacters());
        }

        private List<Character> GetCharacters()
        {
            return new List<Character>()
            {
                new Character(0, "Raiden", "Dark hair, black eyes, tall and well-built.", true, "Start"),
                new Character(1, "Gorro", "Like those in the circus. He really looks bad-tempered. To communicate, talk to him.", false, "Start"),
                new Character(2, "Figure", "You can hear a weak lament and hardly discern a traslucent figure.", false, "Start"),
                new Character(3, "Elfito", "It's an elf curling up on the floor, crying.", false, "Start"),
                new Character(3, "Troll", "It's a solid Troll. He looks grumpy.", false, "Start"),
                new Character(4, "Bear", "It´s a gray bear.", false, "Start"),
                new Character(5, "Maluva dwarf", "It´s a dwarf.", false, "Start"),
        };
        }



    }
}
