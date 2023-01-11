using TextAdventure.Core.Interfaces;
using TextAdventure.Core.Models;

namespace TextAdventure.Core.Actions
{
    public class InventoryAction : ITextAdventureAction
    {
        public Adventure Execute(Adventure adventure)
        {
            var principalCharacter = adventure.Characters.FirstOrDefault(x => x.IsPrincipal);

            if (principalCharacter is not null)
            {
                // READ THE INVENTORY
                adventure.OutputText = "The inventory is: ";
            }

            return adventure;
        }
    }
}
