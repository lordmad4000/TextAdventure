using TextAdventure.Application.Persistence;
using TextAdventure.Core.Exceptions;
using TextAdventure.Core.Models;

namespace TextAdventure.Infrastructure.Repository
{
    public class RoomRepository : IRoomRepository
    {
        public async Task<Room> GetByName(string name)
        {
            var room = GetRooms().FirstOrDefault(x => x.Name.ToLower().Equals(name.ToLower()));
            if (room is null)
                throw new RoomNotFoundException($"Room with Name {name} not found.");

            return await Task.Run(() => room);
        }

        public async Task<Room> GetById(int id)
        {
            var room = GetRooms().FirstOrDefault(x => x.Id == id);
            if (room is null)
                throw new RoomNotFoundException($"Room with Id {id} not found.");

            return await Task.Run(() => room);
        }

        private List<Room> GetRooms()
        {
            var rooms = new List<Room>();
            rooms.Add(SetRoom(0, "Start",
                                   "You are just in the border between the North badlands and the wet forests of the South. Close " +
                                   "to you, to the East, you can see a brick cabin surrounded by a thick grove. A stream flows South.",
                                   new List<Exit>()
                                   {
                                        new Exit(Directions.Northwest, "Northwest", 1),
                                        new Exit(Directions.North, "North", 2),
                                        new Exit(Directions.Northeast, "Northeast", 3),
                                        new Exit(Directions.West, "West", 4),
                                        new Exit(Directions.East, "East", 5),
                                        new Exit(Directions.Southwest, "Southwest", 6),
                                        new Exit(Directions.South, "South", 7),
                                        new Exit(Directions.Southeast, "Southeast", 8),
                                    }));
            rooms.Add(SetRoom(1, "Northwest",
                                  "You are in Northwest region.",
                                  new List<Exit>
                                  {
                                          new Exit(Directions.East, "East", 2),
                                          new Exit(Directions.South, "South", 4),
                                          new Exit(Directions.Southeast, "Southeast", 0),
                                  }));
            rooms.Add(SetRoom(2, "North",
                                 "You are in North region.",
                                 new List<Exit>
                                 {
                                         new Exit(Directions.West, "West", 1),
                                         new Exit(Directions.East, "East", 3),
                                         new Exit(Directions.Southwest, "Southwest", 4),
                                         new Exit(Directions.South, "South", 0),
                                         new Exit(Directions.Southeast, "Southeast", 5),
                                 }));
            rooms.Add(SetRoom(3, "Northeast",
                                 "You are in Northeast region.",
                                 new List<Exit>
                                 {
                                         new Exit(Directions.West, "West", 2),
                                         new Exit(Directions.Southwest, "Southwest", 0),
                                         new Exit(Directions.South, "South", 5),
                                 }));
            rooms.Add(SetRoom(4, "West",
                                 "You are in West region.",
                                 new List<Exit>
                                 {
                                         new Exit(Directions.North, "North", 1),
                                         new Exit(Directions.Northeast, "Northeast", 2),
                                         new Exit(Directions.East, "East", 0),
                                         new Exit(Directions.South, "South", 6),
                                         new Exit(Directions.Southeast, "Southeast", 7),
                                 }));
            rooms.Add(SetRoom(5, "East",
                                 "You are in East region.",
                                 new List<Exit>
                                 {
                                         new Exit(Directions.Northwest, "Northwest", 2),
                                         new Exit(Directions.North, "North", 3),
                                         new Exit(Directions.West, "West", 0),
                                         new Exit(Directions.Southwest, "Southwest", 7),
                                         new Exit(Directions.South, "South", 8),
                                 }));
            rooms.Add(SetRoom(6, "Southwest",
                                 "You are in Southwest region.",
                                 new List<Exit>
                                 {
                                         new Exit(Directions.North, "North", 4),
                                         new Exit(Directions.Northeast, "Northeast", 0),
                                         new Exit(Directions.East, "East", 7),
                                 }));
            rooms.Add(SetRoom(7, "South",
                                 "You are in South region.",
                                 new List<Exit>
                                 {
                                         new Exit(Directions.Northwest, "Northwest", 4),
                                         new Exit(Directions.North, "North", 0),
                                         new Exit(Directions.Northeast, "Northeast", 5),
                                         new Exit(Directions.West, "West", 6),
                                         new Exit(Directions.East, "East", 8),
                                 }));
            rooms.Add(SetRoom(8, "Southeast",
                                 "You are in Southeast region.",
                                 new List<Exit>
                                 {
                                         new Exit(Directions.Northwest, "Northwest", 0),
                                         new Exit(Directions.North, "North", 5),
                                         new Exit(Directions.West, "West", 7),
                                 }));

            return rooms;
        }

        private Room SetRoom(int id, string name, string description, List<Exit> exits)
        {
            var room = new Room(id, name, description);
            foreach (var exit in exits)
            {
                room.AddExit(exit);
            }

            return room;
        }


    }
}
