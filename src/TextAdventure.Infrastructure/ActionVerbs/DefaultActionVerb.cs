using TextAdventure.Core.Actions;
using TextAdventure.Core.Interfaces;
using TextAdventure.Core.Models;

namespace TextAdventure.Infrastructure.ActionVerbs
{
    public class DefaultActionVerb : IActionVerb
    {
        public ITextAdventureAction Check(Phrase phrase)
        {
            return new CantDoAction();
        }

    }
}
