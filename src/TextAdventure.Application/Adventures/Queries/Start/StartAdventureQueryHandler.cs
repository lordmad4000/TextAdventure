using AutoMapper;
using MediatR;
using TextAdventure.Application.Adventures.Dtos;
using TextAdventure.Application.Persistence;
using TextAdventure.Core.Interfaces;
using TextAdventure.Core.Models;

namespace TextAdventure.Application.Adventures.Queries.Start
{
    public class StartAdventureQueryHandler : IRequestHandler<StartAdventureQuery, AdventureDto>
    {
        private readonly IAdventureRepository _adventureRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly ICharacterRepository _characterRepository;
        private readonly IItemRepository _itemRepository;
        private readonly IParserService _parserService;
        private readonly IMapper _mapper;

        public StartAdventureQueryHandler(IAdventureRepository adventureRepository,
                                          IRoomRepository roomRepository,
                                          ICharacterRepository characterRepository,
                                          IItemRepository itemRepository,
                                          IParserService parserService,
                                          IMapper mapper)
        {
            _adventureRepository = adventureRepository;
            _roomRepository = roomRepository;
            _characterRepository = characterRepository;
            _itemRepository = itemRepository;
            _parserService = parserService;
            _mapper = mapper;
        }

        public async Task<AdventureDto> Handle(StartAdventureQuery request, CancellationToken cancellationToken)
        {
            Adventure adventure = await _adventureRepository.GetById(request.Id);
            adventure.ActualRoom = await _roomRepository.GetById(0);
            var characters = await _characterRepository.GetAll();
            foreach (var character in characters)
            {
                adventure.AddCharacter(character);
            }
            var items = await _itemRepository.GetAll();
            foreach (var item in items)
            {
                adventure.AddItem(item);
            }

            return _mapper.Map<AdventureDto>(adventure);
        }
    }

}
