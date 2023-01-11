using AutoMapper;
using MediatR;
using TextAdventure.Application.Adventures.Dtos;
using TextAdventure.Application.Persistence;
using TextAdventure.Core.Interfaces;
using TextAdventure.Core.Models;

namespace TextAdventure.Application.Adventures.Queries.ExecuteCommand
{
    public class ExecuteCommandQueryHandler : IRequestHandler<ExecuteCommandQuery, ExecuteCommandResult>
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IParserService _parserService;
        private readonly IMapper _mapper;

        public ExecuteCommandQueryHandler(IRoomRepository roomRepository, IParserService parserService, IMapper mapper)
        {
            _roomRepository = roomRepository;
            _parserService = parserService;
            _mapper = mapper;
        }

        public async Task<ExecuteCommandResult> Handle(ExecuteCommandQuery request, CancellationToken cancellationToken)
        {
            request.AdventureDto.OutputText = "";
            var textAdventureAction = _parserService.ParseTextInputCommand(request.TextCommand);
            var adventure = textAdventureAction.Execute(_mapper.Map<Adventure>(request.AdventureDto));
            await TryLoadRoom(adventure);
            string outputText = $"{adventure.ActualRoom.Description}{Environment.NewLine}{adventure.OutputText}";

            return new ExecuteCommandResult(request.TextCommand, outputText, _mapper.Map<AdventureDto>(adventure));
        }

        private async Task TryLoadRoom(Adventure adventure)
        {
            if (adventure.LoadRoom)
            {                
                adventure.ActualRoom = await _roomRepository.GetByName(adventure.ActualRoom.Name);
                adventure.LoadRoom = false;
            }
        }

    }
}
