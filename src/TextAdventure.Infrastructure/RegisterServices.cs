using Microsoft.Extensions.DependencyInjection;
using TextAdventure.Application.Persistence;
using TextAdventure.Core.Interfaces;
using TextAdventure.Infrastructure.Repository;
using TextAdventure.Infrastructure.Services;

namespace TextAdventure.Infrastructure
{
    public static class RegisterServices
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IAdventureRepository, AdventureRepository>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<ICharacterRepository, CharacterRepository>();
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IParserService, ParserService>();

            return services;
        }
    }
}
