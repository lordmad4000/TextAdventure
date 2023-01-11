using TextAdventure.Core.Interfaces;
using TextAdventure.Core.Models;

namespace TextAdventure.Core.Actions
{
    public class CloseAction : ITextAdventureAction
    {
        private string ItemName { get; set; }

        public CloseAction(string itemName)
        {
            ItemName = itemName;
        }

        public Adventure Execute(Adventure adventure)
        {
            adventure.OutputText = $"You close the {ItemName}";

            return adventure;
        }
    }
}
