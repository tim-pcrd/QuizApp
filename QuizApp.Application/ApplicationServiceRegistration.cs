using MediatR;
using Microsoft.Extensions.DependencyInjection;
using QuizApp.Application.Helpers;
using QuizApp.Application.Interfaces.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ApplicationServiceRegistration).Assembly);
            services.AddMediatR(typeof(ApplicationServiceRegistration).Assembly);
            services.AddTransient(typeof(IValidation<,>), typeof(Validation<,>));
            return services;
        }
    }
}
