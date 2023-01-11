using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace TextAdventure.Application
{
    public static class RegisterServices
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(typeof(RegisterServices).Assembly);

            return services;
        }
    }
}
