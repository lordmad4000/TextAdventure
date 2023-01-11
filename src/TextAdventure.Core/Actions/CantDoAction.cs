using TextAdventure.Core.Interfaces;
using TextAdventure.Core.Models;

namespace TextAdventure.Core.Actions
{
    public class CantDoAction : ITextAdventureAction
    {
        public Adventure Execute(Adventure adventure)
        {
            adventure.OutputText = "Can´t do that.";

            return adventure;
        }
    }
}
