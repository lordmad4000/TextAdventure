using TextAdventure.Core.Repository;
using TextAdventure.Core.Models;
using System.Net.Http.Headers;

namespace TextAdventure.Core.Services
{
    public class CommandService : ICommandService
    {
        private readonly IAdventureRepository _adventureRepository;
        private readonly IRoomRepository _roomRepository;

        public CommandService(IAdventureRepository adventureRepository, IRoomRepository roomRepository)
        {
            _adventureRepository = adventureRepository;
            _roomRepository = roomRepository;
        }

        public async Task<Command> ExecuteCommand(Command command)
        {
            Exit? exit = null;
            if (command.TextInput.ToLower() == "start")
            {
                command.Adventure = await _adventureRepository.GetById(0);
                command.Adventure.ActualRoom = await _roomRepository.GetById(0);
            }
            else
            {
                switch (command.TextInput.ToLower())
                {
                    case "northwest": { exit = command.Adventure.ActualRoom.Exits.FirstOrDefault(x => x.Direction == Directions.Northwest); break; }
                    case "north": { exit = command.Adventure.ActualRoom.Exits.FirstOrDefault(x => x.Direction == Directions.North); break; }
                    case "northeast": { exit = command.Adventure.ActualRoom.Exits.FirstOrDefault(x => x.Direction == Directions.Northeast); break; }
                    case "west": { exit = command.Adventure.ActualRoom.Exits.FirstOrDefault(x => x.Direction == Directions.West); break; }
                    case "east": { exit = command.Adventure.ActualRoom.Exits.FirstOrDefault(x => x.Direction == Directions.East); break; }
                    case "southwest": { exit = command.Adventure.ActualRoom.Exits.FirstOrDefault(x => x.Direction == Directions.Southwest); break; }
                    case "south": { exit = command.Adventure.ActualRoom.Exits.FirstOrDefault(x => x.Direction == Directions.South); break; }
                    case "southeast": { exit = command.Adventure.ActualRoom.Exits.FirstOrDefault(x => x.Direction == Directions.Southeast); break; }
                }

            }

            if (exit is not null)
            {
                command.Adventure.ActualRoom = await _roomRepository.GetById(exit.RoomId);
            }

            return new Command(command.TextInput, command.Adventure.ActualRoom.Description, command.Adventure);
        }
    }
}
