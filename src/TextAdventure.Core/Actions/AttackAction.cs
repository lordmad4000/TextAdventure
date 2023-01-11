using TextAdventure.Core.Interfaces;
using TextAdventure.Core.Models;

namespace TextAdventure.Core.Actions
{
    public class AttackAction : ITextAdventureAction
    {
        private string CharacterName { get; set; }
        private string ItemName { get; set; }

        public AttackAction(string characterName, string itemName)
        {
            CharacterName = characterName;
            ItemName = itemName;
        }

        public Adventure Execute(Adventure adventure)
        {
            if (!string.IsNullOrEmpty(CharacterName))
            {
                adventure.OutputText += $"You attack {CharacterName}";
            }
            if (!string.IsNullOrEmpty(ItemName))
            {
                adventure.OutputText = $"with the {ItemName}";
            }

            return adventure;
        }
    }
}
