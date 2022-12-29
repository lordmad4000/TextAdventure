namespace TextAdventure.Core.Models
{
    public class Adventure
    {
        public Adventure()
        {
            Id = 0;
            Name = "";
            Description = "";
            ActualRoom = new Room(0, "", "");
            Items = new List<Item>();
            Characters = new List<Character>();
            Exits = new List<Exit>();
        }

        public Adventure(int id, string name, string description, Room actualRoom, List<Item> items, List<Character> characters, List<Exit> exits)
        {
            Id = id;
            Name = name;
            Description = description;
            ActualRoom = actualRoom;
            Items = items;
            Characters = characters;
            Exits = exits;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Room ActualRoom { get; set; }
        public List<Item> Items { get; set; }
        public List<Character> Characters { get; set; }
        public List<Exit> Exits { get; set; }

    }
}
