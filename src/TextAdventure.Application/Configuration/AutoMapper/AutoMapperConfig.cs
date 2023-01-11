using AutoMapper;

namespace TextAdventure.Application.Configuration.AutoMapper
{
    public static class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AllowNullCollections = true;
                cfg.AllowNullDestinationValues = true;
                cfg.AddProfile(new ApplicationMappingProfile());
            });
        }
    }
}
