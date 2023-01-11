using TextAdventure.Core.Actions;
using TextAdventure.Core.Interfaces;
using TextAdventure.Core.Models;

namespace TextAdventure.Infrastructure.ActionVerbs
{
    public class AskActionVerb : IActionVerb
    {
        private List<string> Verbs = new List<string>() { "ask", "tell" };

        public ITextAdventureAction Check(Phrase phrase)
        {
            ITextAdventureAction action = new CantDoAction();
            if (Verbs.Any(x => x.Equals(phrase.Verb)) && !string.IsNullOrWhiteSpace(phrase.Parameter1))
            {
                action = new AskAction(phrase.Parameter1, phrase.Parameter2);
            }

            return action;
        }

    }
}
