using TextAdventure.Core.Models;

namespace TextAdventure.Application.Adventures.Dtos
{
    public class AdventureDto
    {
        public AdventureDto(int id, string name, string description, string outputText, Room actualRoom, List<Item> items, List<Character> characters, bool loadRoom)
        {
            Id = id;
            Name = name;
            Description = description;
            OutputText = outputText;
            ActualRoom = actualRoom;
            Items = items;
            Characters = characters;
            LoadRoom = loadRoom;
        }

        public int Id { get; }
        public string Name { get; }
        public string Description { get; }
        public string OutputText { get; set; }
        public Room ActualRoom { get; set; }
        public List<Item> Items { get; }
        public List<Character> Characters { get; }
        public bool LoadRoom { get; }

    }
}
