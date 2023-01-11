using AutoMapper;
using TextAdventure.Application.Adventures.Queries.Execute;
using TextAdventure.Core.Models;

namespace TextAdventure.Application.Configuration.AutoMapper
{
    public class ApplicationMappingProfile : Profile
    {
        public ApplicationMappingProfile() 
        {
            CreateMap<Adventure, AdventureDto>();
            CreateMap<AdventureDto, Adventure>();
        }
    }
}
