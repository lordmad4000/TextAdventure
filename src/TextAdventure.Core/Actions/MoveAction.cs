using TextAdventure.Core.Interfaces;
using TextAdventure.Core.Models;

namespace TextAdventure.Core.Actions
{
    public class MoveAction : ITextAdventureAction
    {
        private string ItemName { get; set; }

        public MoveAction(string itemName)
        {
            ItemName = itemName;
        }

        public Adventure Execute(Adventure adventure)
        {
            adventure.OutputText = $"You move the {ItemName}";

            return adventure;
        }
    }
}
