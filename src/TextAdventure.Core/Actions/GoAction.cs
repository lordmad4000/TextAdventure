using TextAdventure.Core.Interfaces;
using TextAdventure.Core.Models;

namespace TextAdventure.Core.Actions
{
    public class GoAction : ITextAdventureAction
    {
        public Directions Direction { get; set; }

        public GoAction(Directions direction)
        {
            Direction = direction;
        }

        public Adventure Execute(Adventure adventure)
        {
            Exit? exit = adventure.ActualRoom.Exits.FirstOrDefault(x => x.Direction == Direction);
            if (exit is not null)
            {
                adventure.LoadRoom = true;
                adventure.ActualRoom.Name = exit.RoomName;
            }

            return adventure;
        }
    }
}
