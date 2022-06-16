using Blog_implementation.Service.ForumService;
using Blog_implementation.Service.PostService;
using ForumBackend.Data;
using Microsoft.EntityFrameworkCore;
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
        public static IServiceCollection AddFroumDependence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IForumService, ForumService>();
            services.AddScoped<IPostService,PostService>();
           
            return services;
        }
    }
}
