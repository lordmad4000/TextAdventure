using Microsoft.Extensions.DependencyInjection;
using TextAdventure.Core.Services;

namespace TextAdventure.Core
{
    public static class RegisterServices
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            services.AddScoped<ICommandService, CommandService>();

            return services;
        }
    }
}
