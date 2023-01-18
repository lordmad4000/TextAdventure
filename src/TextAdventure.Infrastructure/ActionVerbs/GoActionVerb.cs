using TextAdventure.Core.Actions;
using TextAdventure.Core.Interfaces;
using TextAdventure.Core.Models;

namespace TextAdventure.Infrastructure.ActionVerbs
{
    public class GoActionVerb : IActionVerb
    {
        private List<string> Verbs = new List<string>() { "go", "move", };
        private Dictionary<string, Directions> Parameter1Directions = new Dictionary<string, Directions>
        {
            { "northwest", Directions.Northwest },
            { "nw", Directions.Northwest },
            { "north", Directions.North },
            { "n", Directions.North },
            { "northeast", Directions.Northeast },
            { "ne", Directions.Northeast },
            { "west", Directions.West },
            { "w", Directions.West },
            { "east", Directions.East },
            { "e", Directions.East },
            { "southwest", Directions.Southwest },
            { "sw", Directions.Southwest },
            { "south", Directions.South },
            { "s", Directions.South },
            { "southeast", Directions.Southeast },
            { "se", Directions.Southeast },
            { "up", Directions.Up },
            { "down", Directions.Down },
            { "inside", Directions.Inside },
            { "outside", Directions.Outside },
        };

        public ITextAdventureAction Check(Phrase phrase)
        {
            if (NotExistsVerb(phrase.Verb) || NotExistsParameter1(phrase.Parameter1))
            {
                return new CantDoAction();
            }

            var parameter1Direction = Parameter1Directions.FirstOrDefault(x => x.Key.ToLower().Equals(phrase.Parameter1.ToLower()));

            return new GoAction(parameter1Direction.Value);
        }

        private bool NotExistsVerb(string verb)
        {
            if (!Verbs.Any(x => x.ToLower().Equals(verb.ToLower())))
            {
                return true;
            }

            return false;
        }

        private bool NotExistsParameter1(string parameter1)
        {
            if (!Parameter1Directions.Any(x => x.Key.ToLower().Equals(parameter1.ToLower())))
            {
                return true;
            }

            return false;
        }

    }

}
