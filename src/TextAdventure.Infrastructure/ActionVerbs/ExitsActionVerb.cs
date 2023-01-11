using TextAdventure.Core.Actions;
using TextAdventure.Core.Interfaces;
using TextAdventure.Core.Models;

namespace TextAdventure.Infrastructure.ActionVerbs
{
    public class ExitsActionVerb : IActionVerb
    {
        private List<string> Verbs = new List<string>() { "exits" };

        public ITextAdventureAction Check(Phrase phrase)
        {
            if (!Verbs.Any(x => x.Equals(phrase.Verb)))
            {
                return new CantDoAction();
            }

            return new ExitsAction();
        }


    }
}
