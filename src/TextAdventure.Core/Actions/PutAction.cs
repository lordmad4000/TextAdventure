using TextAdventure.Core.Interfaces;
using TextAdventure.Core.Models;

namespace TextAdventure.Core.Actions
{
    public class PutAction : ITextAdventureAction
    {
        private string Item1Name { get; set; }
        private string Item2Name { get; set; }

        public PutAction(string item1Name, string item2Name)
        {
            Item1Name = item1Name;
            Item2Name = item2Name;
        }

        public Adventure Execute(Adventure adventure)
        {
            adventure.OutputText = $"You use the {Item1Name} on {Item2Name}";

            return adventure;
        }
    }
}
