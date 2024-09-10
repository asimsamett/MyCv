using FluentValidation;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MyCv.Application.CQRS.AdminCQ.AdminCreate.NotificationHandler;
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
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidatorDI<,>));
            services.Configure<RabbitMQSettings>(configuration.GetSection("RabbitMQSettings"));

            services.AddMassTransit(x =>
            {
                x.UsingRabbitMq((context, cfg) =>
                {
                    var settings = context.GetRequiredService<IOptions<RabbitMQSettings>>().Value;

                    cfg.Host(
                        host: settings.Hostname,
                        port: 5672,
                        virtualHost: "dvyztrut", 
                        configure:  h => {
                            h.Username(settings.Username);
                            h.Password(settings.Password);
                        });
                    cfg.ReceiveEndpoint("notifications", e =>
                    {
                        e.ConfigureConsumer<AdminEventHandler>(context);
                    });
                });
                x.AddConsumer<AdminEventHandler>();
            });

        }
    }
}
