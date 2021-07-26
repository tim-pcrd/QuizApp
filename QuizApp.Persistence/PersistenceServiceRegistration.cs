using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuizApp.Application.Interfaces.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<QuizDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("QuizAppConnectionString"));
                options.EnableSensitiveDataLogging();
            });

            services.AddScoped<IDbContext>(provider => provider.GetService<QuizDbContext>());


            return services;
        }
    }
}
