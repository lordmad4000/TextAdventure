using TextAdventure.Core.Interfaces;
using TextAdventure.Core.Models;

namespace TextAdventure.Core.Actions
{
    public class UseAction : ITextAdventureAction
    {
        private string ItemName { get; set; }

        public UseAction(string itemName)
        {
            ItemName = itemName;
        }

        public Adventure Execute(Adventure adventure)
        {
            adventure.OutputText = $"You use the {ItemName}";

            return adventure;
        }
    }
}
