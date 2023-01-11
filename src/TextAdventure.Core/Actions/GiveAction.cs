using TextAdventure.Core.Interfaces;
using TextAdventure.Core.Models;

namespace TextAdventure.Core.Actions
{
    public class GiveAction : ITextAdventureAction
    {
        private string ItemName { get; set; }
        private string CharacterName { get; set; }

        public GiveAction(string itemName, string characterName)
        {
            ItemName = itemName;
            CharacterName = characterName;
        }

        public Adventure Execute(Adventure adventure)
        {
            if (!string.IsNullOrEmpty(ItemName))
            {
                adventure.OutputText = $"You give the {ItemName}";
            }
            if (!string.IsNullOrEmpty(CharacterName))
            {
                adventure.OutputText += $"to {CharacterName}";
            }

            return adventure;
        }
    }
}
