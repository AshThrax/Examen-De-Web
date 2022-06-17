using Application.Common.Interfaces;
using infrastructure.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services ,IConfiguration configuration)
        {

            services.AddScoped<IFilmService, FilmService>();
            services.AddScoped<IActeurService, ActeurService>();
            return services;
        }
    }
}