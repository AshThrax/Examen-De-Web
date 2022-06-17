using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this ServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            //injectionde mediator
            services.AddMediatR(Assembly.GetExecutingAssembly());
           
            return services;
        }
    }
}
