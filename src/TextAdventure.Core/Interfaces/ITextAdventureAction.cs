using TextAdventure.Core.Models;

namespace TextAdventure.Core.Interfaces
{
    public interface ITextAdventureAction
    {
        Adventure Execute(Adventure adventure);
    }
}