using TextAdventure.Core.Interfaces;
using TextAdventure.Core.Models;

namespace TextAdventure.Core.Actions
{
    public class OpenAction : ITextAdventureAction
    {
        private string ItemName { get; set; }

        public OpenAction(string itemName)
        {
            ItemName = itemName;
        }

        public Adventure Execute(Adventure adventure)
        {
            adventure.OutputText = $"You open the {ItemName}";

            return adventure;
        }
    }
}
