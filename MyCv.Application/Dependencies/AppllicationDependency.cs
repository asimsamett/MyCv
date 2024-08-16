using FluentValidation;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyCv.Application.Dependencies
{
    public static class ApplicationDependency
    {
        public static void AddAplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg=>cfg.RegisterServicesFromAssemblies(typeof(ApplicationDependency).Assembly));
            
            
        }
    }
}
