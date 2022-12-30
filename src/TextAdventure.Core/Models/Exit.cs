namespace TextAdventure.Core.Models
{
    public class Exit
    {
        public Exit(Directions direction, int roomId, string roomName)
        {
            Direction = direction;
            RoomId = roomId;
            RoomName = roomName;
        }

        public Directions Direction { get; set; }
        public int RoomId { get; set; }
        public string RoomName { get; set; }

    }
}
