using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Saul.Test.Application.Interface.Infrastructure;
using Saul.Test.Infrastructure.EventBus;
using Saul.Test.Infrastructure.EventBus.Options;
using Saul.Test.Infrastructure.Notification;
using Saul.Test.Infrastructure.Notification.Options;
using SendGrid.Extensions.DependencyInjection;

namespace Saul.Test.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.ConfigureOptions<RabbitMqOptionsSetup>();
            services.AddScoped<IEventBus, EventBusRabbitMQ>();
            services.AddMassTransit(x =>
            {
                x.UsingRabbitMq((context, cfg) =>
                {
                    RabbitMqOptions? opt = services.BuildServiceProvider()
                    .GetRequiredService<IOptions<RabbitMqOptions>>()
                    .Value;

                    cfg.Host(opt.HostName, opt.VirtualHost, h =>
                    {
                        h.Username(opt.UserName);
                        h.Password(opt.Password);
                    });
                    cfg.ConfigureEndpoints(context);
                });
            });

            //Sendgrid
            services.AddScoped<INotification, NotificationSendGrid>();
            services.ConfigureOptions<SendgridOptionsSetup>();
            SendgridOptions? sendgridOptions = services.BuildServiceProvider()
                .GetRequiredService<IOptions<SendgridOptions>>()
                .Value;

            services.AddSendGrid((options =>
            {
                options.ApiKey = sendgridOptions.ApiKey;
            }));

            return services;
        }


    }
}
