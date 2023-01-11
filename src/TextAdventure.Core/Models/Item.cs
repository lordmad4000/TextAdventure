namespace TextAdventure.Core.Models
{
    public class Item
    {
        public Item(int id, string description, string locationName)
        {
            Id = id;
            Names = new List<string>();
            Description = description;
            LocationName = locationName;
        }

        public Item(int id, string name1, string name2, string name3, string name4, string description, string locationName)
        {
            Id = id;
            Names = new List<string>();
            AddName(name1);
            AddName(name2);
            AddName(name3);
            AddName(name4);
            Description = description;
            LocationName = locationName;
        }

        public int Id { get; private set; }
        public List<string> Names { get; private set; }
        public string Description { get; private set; }
        public string LocationName { get; private set; }

        public void AddName(string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                Names.Add(name);
            }
        }

    }
}
