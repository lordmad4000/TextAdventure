using TextAdventure.Core.Models;

namespace TextAdventure.Core.Interfaces
{
    public interface IActionVerb
    {
        ITextAdventureAction Check(Phrase phrase);
    }
}
