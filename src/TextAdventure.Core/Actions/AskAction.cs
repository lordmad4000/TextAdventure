using TextAdventure.Core.Interfaces;
using TextAdventure.Core.Models;

namespace TextAdventure.Core.Actions
{
    public class AskAction : ITextAdventureAction
    {
        public string ItemName { get; private set; }
        public string Character1Name { get; private set; }
        public string Character2Name { get; private set; }
        private readonly string _parameter1;
        private readonly string _parameter2;

        public AskAction(string parameter1, string parameter2)
        {
            ItemName = "";
            Character1Name = "";
            Character2Name = "";
            _parameter1 = parameter1.ToLower();
            _parameter2 = parameter2.ToLower();
        }

        public Adventure Execute(Adventure adventure)
        {
            SetProperties(adventure);
            if (!string.IsNullOrEmpty(ItemName) && string.IsNullOrEmpty(Character1Name))
            {
                adventure.OutputText = $"You ask about the {ItemName}";
            }
            if (!string.IsNullOrEmpty(Character1Name) && string.IsNullOrEmpty(ItemName))
            {
                adventure.OutputText = $"You ask about {Character1Name}";
            }
            if (!string.IsNullOrEmpty(Character1Name) && !string.IsNullOrEmpty(ItemName))
            {
                adventure.OutputText = $"You ask {Character1Name} about the {ItemName}";
            }
            if (!string.IsNullOrEmpty(Character1Name) && string.IsNullOrEmpty(ItemName) && !string.IsNullOrEmpty(Character2Name))
            {
                adventure.OutputText = $"You ask {Character1Name} about {Character2Name}";
            }

            return adventure;
        }

        private void SetProperties(Adventure adventure)
        {
            var itemsInThisRoom = adventure.Items.Where(x => x.LocationName.ToLower() == adventure.ActualRoom.Name.ToLower());
            var charactersInThisRoom = adventure.Characters.Where(x => x.LocationName.ToLower() == adventure.ActualRoom.Name.ToLower());

            if (itemsInThisRoom.Any(x => x.Names.Any(y => y.ToLower().Equals(_parameter1))))
            {
                ItemName = _parameter1;
            }
            else if (charactersInThisRoom.Any(x => x.Name.ToLower().Equals(_parameter1)))
            {
                Character1Name = _parameter1;
            }
            if (itemsInThisRoom.Any(x => x.Names.Any(y => y.ToLower().Equals(_parameter2))))
            {
                ItemName = _parameter2;
            }
            else if (charactersInThisRoom.Any(x => x.Name.ToLower().Equals(_parameter2)))
            {
                Character2Name = _parameter2;
            }
        }
    }
}
