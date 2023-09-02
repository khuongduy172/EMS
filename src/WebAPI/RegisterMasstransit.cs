using MassTransit;
using MessagingCore;
using System.Reflection;

namespace WebAPI;

public static class RegisterMasstransit
{
    public static void AddRequestClient(this IBusRegistrationConfigurator busRegistrationConfigurator)
    {
        //busRegistrationConfigurator.AddRequestClient<WeatherForecast>();
    }

    public static void ConfigureConsumer(this IRabbitMqReceiveEndpointConfigurator rabbitMqReceiveEndpointConfigurator, IBusRegistrationContext busRegistrationContext)
    {
        //rabbitMqReceiveEndpointConfigurator.ConfigureConsumer<WeatherForecastConsumer>(busRegistrationContext);
    }

    public static void ConfigureMassTransit(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMassTransit(x =>
        {
            var assembly = Assembly.GetEntryAssembly();

            x.AddConsumers(assembly);
            x.AddRequestClient();
            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(configuration.GetConnectionString("RabbitMQ"));

                cfg.ReceiveEndpoint(Constants.QueueNames.WebAPI, e =>
                {
                    e.ConfigureConsumer(context);
                });

                cfg.ConfigureEndpoints(context);
            });
        });
    }
}