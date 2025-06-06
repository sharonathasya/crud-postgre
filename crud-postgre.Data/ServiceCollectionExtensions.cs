﻿using crud.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace NaturalTwenty.Data
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterDataServices(
            this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<dbContext>(o => 
            o.UseNpgsql(configuration.GetConnectionString("ApiContext")
            ));
            return services;
        }
    }
}
