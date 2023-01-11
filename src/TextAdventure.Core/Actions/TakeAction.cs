using TextAdventure.Core.Interfaces;
using TextAdventure.Core.Models;

namespace TextAdventure.Core.Actions
{
    public class TakeAction : ITextAdventureAction
    {
        private string ItemName { get; set; }
        private string CharacterName { get; set; }

        public TakeAction(string itemName, string characterName)
        {
            ItemName = itemName;
            CharacterName = characterName;
        }

        public Adventure Execute(Adventure adventure)
        {
            adventure.OutputText = $"You take the {ItemName}";
            if (!string.IsNullOrEmpty(CharacterName))
            {
                adventure.OutputText += $" from {CharacterName}";
            }

            return adventure;
        }
    }
}
