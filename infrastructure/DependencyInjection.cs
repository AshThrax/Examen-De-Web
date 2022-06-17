using Application.Common.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this ServiceCollection services ,IConfiguration configuration)
        {

            services.AddScoped<IFilmService, FilmService>();
            services.AddScoped<IActeurService, ServiceActeur>();
            return services;
        }
    }
}