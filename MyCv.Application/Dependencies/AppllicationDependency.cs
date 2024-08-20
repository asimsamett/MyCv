using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace MyCv.Application.Dependencies
{

    public static class ApplicationDependency
    {
        /// <summary>
        /// AddAplicationServices
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void AddAplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg=>cfg.RegisterServicesFromAssemblies(typeof(ApplicationDependency).Assembly));
        }
    }
}
