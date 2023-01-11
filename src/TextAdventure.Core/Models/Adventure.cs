namespace TextAdventure.Core.Models
{
    public class Adventure
    {
        public Adventure(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
            OutputText = "";
            ActualRoom = new Room(0, "", "");
            LoadRoom = false;
            Items = new List<Item>();
            Characters = new List<Character>();
        }

        public int Id { get; }
        public string Name { get; }
        public string Description { get; }
        public string OutputText { get; set; }
        public Room ActualRoom { get; set; }
        public List<Item> Items { get; }
        public List<Character> Characters { get; }
        public bool LoadRoom { get; set; }

        public void AddItem(Item item) => Items.Add(item);

        public void RemoveItem(Item item) => Items.Remove(item);

        public void AddCharacter(Character character)
        {
            if (character.IsPrincipal)
            {
                if (Characters.Any(x => x.IsPrincipal))
                {
                    character.IsPrincipal = false;
                }
            }
            Characters.Add(character);
        }

    }
}
