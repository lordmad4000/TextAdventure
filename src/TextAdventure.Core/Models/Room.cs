namespace TextAdventure.Core.Models
{
    public class Room
    {
        public Room(int id, string name, string description, List<Exit> exits)
        {
            Id = id;
            Name = name;
            Description = description;
            Exits = exits;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Exit> Exits { get; set; }

    }
}
