using Microsoft.Extensions.DependencyInjection;
using TextAdventure.Core.Repository;
using TextAdventure.Infrastructure.Repository;

namespace TextAdventure.Infrastructure
{
    public static class RegisterServices
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IAdventureRepository, AdventureRepository>();
            services.AddScoped<IRoomRepository, RoomRepository>();

            return services;
        }
    }
}
