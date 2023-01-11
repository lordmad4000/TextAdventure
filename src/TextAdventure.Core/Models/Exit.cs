namespace TextAdventure.Core.Models
{
    public class Exit
    {
        public Exit(Directions direction, string roomName, int roomId)
        {
            Direction = direction;
            RoomName = roomName;
            RoomId = roomId;
        }

        public Directions Direction { get; set; }
        public string RoomName { get; set; }
        public int RoomId { get; set; }

    }
}
