using TextAdventure.Core.Interfaces;
using TextAdventure.Core.Models;

namespace TextAdventure.Core.Actions
{
    public class LookAction : ITextAdventureAction
    {
        private string ItemName { get; set; }
        private string CharacterName { get; set; }

        public LookAction(string itemName, string characterName)
        {
            ItemName = itemName;
            CharacterName = characterName;
        }

        public Adventure Execute(Adventure adventure)
        {
            adventure.OutputText = adventure.ActualRoom.Description;
            if (!string.IsNullOrEmpty(ItemName))
            {
                adventure.OutputText = $"You look at {ItemName}";
            }
            else if (!string.IsNullOrEmpty(CharacterName))
            {
                adventure.OutputText = $"You look at {CharacterName}";
            }

            return adventure;
        }
    }
}
