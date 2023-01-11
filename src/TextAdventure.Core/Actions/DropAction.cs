using TextAdventure.Core.Interfaces;
using TextAdventure.Core.Models;

namespace TextAdventure.Core.Actions
{
    public class DropAction : ITextAdventureAction
    {
        private string ItemName { get; set; }

        public DropAction(string itemName)
        {
            ItemName = itemName;
        }

        public Adventure Execute(Adventure adventure)
        {
            adventure.OutputText = $"You drop the {ItemName}";

            return adventure;
        }
    }
}
