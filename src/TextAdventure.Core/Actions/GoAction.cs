using TextAdventure.Core.Interfaces;
using TextAdventure.Core.Models;

namespace TextAdventure.Core.Actions
{
    public class GoAction : ITextAdventureAction
    {
        private Directions Direction { get; set; }

        public GoAction(Directions direction)
        {
            Direction = direction;
        }

        public Adventure Execute(Adventure adventure)
        {
            Exit? exit = adventure.ActualRoom.Exits.FirstOrDefault(x => x.Direction == Directions.Northwest);
            if (exit is not null)
            {
                //adventure = new Adventure();
                adventure.LoadRoom = true;
                adventure.ActualRoom.Id = exit.RoomId;
            }

            return adventure;
        }
    }
}
