namespace TextAdventure.Core.Models
{
    public class Room
    {
        public Room(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
            Exits = new List<Exit>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Exit> Exits { get; }

        public void AddExit(Exit exit) => Exits.Add(exit);
        public void RemoveExit(Exit exit) => Exits.Remove(exit);

    }
}
