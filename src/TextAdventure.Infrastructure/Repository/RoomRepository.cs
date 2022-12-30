using TextAdventure.Core.Repository;
using TextAdventure.Core.Models;
using TextAdventure.Core.Exceptions;

namespace TextAdventure.Infrastructure.Repository
{
    public class RoomRepository : IRoomRepository
    {
        public async Task<Room> GetById(int id)
        {
            var room = GetRooms().FirstOrDefault(x => x.Id == id);
            if (room is null)
                throw new RoomNotFoundException($"Room with Id {id} not found."); 

            return await Task.Run(() => room);
        }

        private List<Room> GetRooms()
        {
            return new List<Room>()
            {
                new Room( 0, "Start",
                          "You are just in the border between the North badlands and the wet forests of the South. Close " +
                          "to you, to the East, you can see a brick cabin surrounded by a thick grove. A stream flows South.",
                          new List<Exit>
                          {
                              new Exit(Directions.Northwest, 1, ""),
                              new Exit(Directions.North, 2, ""),
                              new Exit(Directions.Northeast, 3, ""),
                              new Exit(Directions.West, 4, ""),
                              new Exit(Directions.East, 5, ""),
                              new Exit(Directions.Southwest, 6, ""),
                              new Exit(Directions.South, 7, ""),
                              new Exit(Directions.Southeast, 8, ""),
                          }),
                new Room( 1, "Northwest",
                          "You are in Northwest region.",
                          new List<Exit>
                          {
                              new Exit(Directions.East, 2, ""),
                              new Exit(Directions.South, 4, ""),
                              new Exit(Directions.Southeast, 0, ""),
                          }),
                new Room( 2, "North",
                          "You are in North region.",
                          new List<Exit>
                          {
                              new Exit(Directions.West, 1, ""),
                              new Exit(Directions.East, 3, ""),
                              new Exit(Directions.Southwest, 4, ""),
                              new Exit(Directions.South, 0, ""),
                              new Exit(Directions.Southeast, 5, ""),
                          }),
                new Room( 3, "Northeast",
                          "You are in Northeast region.",
                          new List<Exit>
                          {
                              new Exit(Directions.West, 2, ""),
                              new Exit(Directions.Southwest, 0, ""),
                              new Exit(Directions.South, 5, ""),
                          }),
                new Room( 4, "West",
                          "You are in West region.",
                          new List<Exit>
                          {
                              new Exit(Directions.North, 1, ""),
                              new Exit(Directions.Northeast, 2, ""),
                              new Exit(Directions.East, 0, ""),
                              new Exit(Directions.South, 6, ""),
                              new Exit(Directions.Southeast, 7, ""),
                          }),
                new Room( 5, "East",
                          "You are in East region.",
                          new List<Exit>
                          {
                              new Exit(Directions.Northwest, 2, ""),
                              new Exit(Directions.North, 3, ""),
                              new Exit(Directions.West, 0, ""),
                              new Exit(Directions.Southwest, 7, ""),
                              new Exit(Directions.South, 8, ""),
                          }),
                new Room( 6, "Southwest",
                          "You are in Southwest region.",
                          new List<Exit>
                          {
                              new Exit(Directions.North, 4, ""),
                              new Exit(Directions.Northeast, 0, ""),
                              new Exit(Directions.East, 7, ""),
                          }),
                new Room( 7, "South",
                          "You are in South region.",
                          new List<Exit>
                          {
                              new Exit(Directions.Northwest, 4, ""),
                              new Exit(Directions.North, 0, ""),
                              new Exit(Directions.Northeast, 5, ""),
                              new Exit(Directions.West, 6, ""),
                              new Exit(Directions.East, 8, ""),
                          }),
                new Room( 8, "Southeast",
                          "You are in Southeast region.",
                          new List<Exit>
                          {
                              new Exit(Directions.Northwest, 0, ""),
                              new Exit(Directions.North, 5, ""),
                              new Exit(Directions.West, 7, ""),
                          })
            };
        }
    }
}
