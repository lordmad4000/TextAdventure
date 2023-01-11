namespace TextAdventure.Core.Models
{
    public class Character
    {
        public Character(int id, string name, string description, bool isPrincipal, string locationName)
        {
            Id = id;
            Name = name;
            Description = description;
            IsPrincipal = isPrincipal;
            LocationName = locationName;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public bool IsPrincipal { get; set; }
        public string LocationName { get; private set; }
    }
}
