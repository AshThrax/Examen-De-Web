using Application.Common.Behaviours;
using Application.Common.Interfaces.Application.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using FluentValidation;
using Api.Infrastructure.Persistence;

namespace Api
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddDependence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidatorBehavior<,>));
            if (configuration.GetValue<bool>("UseInMemoryDatabase") )
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseInMemoryDatabase("CleanArchDb"));
            }
            else
            {
                        services.AddDbContext<ApplicationDbContext>(options =>
                        options.UseSqlServer(
                            configuration.GetConnectionString("DefaultConnection"),
                            b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            }
           

            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());
            return services;
        }
    }
}
