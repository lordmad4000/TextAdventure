using TextAdventure.Core.Interfaces;
using TextAdventure.Core.Models;

namespace TextAdventure.Core.Actions
{
    public class SayAction : ITextAdventureAction
    {
        private string Phrase { get; set; }
        private string CharacterName { get; set; }

        public SayAction(string phrase, string characterName)
        {
            Phrase = phrase;
            CharacterName = characterName;
        }

        public Adventure Execute(Adventure adventure)
        {
            adventure.OutputText = $"You say {Phrase}";
            if (!string.IsNullOrEmpty(CharacterName))
            {
                adventure.OutputText += $" to {CharacterName}";
            }

            return adventure;
        }
    }
}
