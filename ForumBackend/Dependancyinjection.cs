using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumBackend
{
    public static  class Dependancyinjection
    {
        public static IServiceCollection AddDependence(this IServiceCollection services, IConfiguration configuration)
        {

            return services;
        }
    }
}
