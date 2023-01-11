using TextAdventure.Core.Interfaces;
using TextAdventure.Core.Models;

namespace TextAdventure.Core.Actions
{
    public class TurnAction : ITextAdventureAction
    {
        private string OnOff { get; set; }
        private string ItemName { get; set; }

        public TurnAction(string onOff, string itemName)
        {
            OnOff = onOff.ToLower();
            ItemName = itemName;
        }

        public Adventure Execute(Adventure adventure)
        {
            if (OnOff.Equals("on"))
            {
                adventure.OutputText = $"You turn on the {ItemName}";
            }
            if (OnOff.Equals("off"))
            {
                adventure.OutputText = $"You turn off the {ItemName}";
            }

            return adventure;
        }
    }
}
