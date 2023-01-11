using MediatR;
using TextAdventure.Application.Adventures.Dtos;

namespace TextAdventure.Application.Adventures.Queries.Start
{
    public class StartAdventureQuery : IRequest<AdventureDto>
    {
        public StartAdventureQuery(int id)
        {
            Id = id;
        }

        public int Id { get; }

    }
}
