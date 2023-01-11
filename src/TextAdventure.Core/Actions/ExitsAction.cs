using System.Text;
using TextAdventure.Core.Interfaces;
using TextAdventure.Core.Models;

namespace TextAdventure.Core.Actions
{
    public class ExitsAction : ITextAdventureAction
    {
        public Adventure Execute(Adventure adventure)
        {
            StringBuilder exitsText = new StringBuilder("The exits are ");
            foreach (var exit in adventure.ActualRoom.Exits)
            {
                if (exit != adventure.ActualRoom.Exits.First())
                {
                    exitsText.Append($", ");
                }
                exitsText.Append($"{exit.Direction.ToString()}");
            }
            exitsText.Append(".");
            adventure.OutputText = exitsText.ToString();

            return adventure;
        }
    }
}
