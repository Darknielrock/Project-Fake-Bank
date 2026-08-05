using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PaymentGateway.Application.Common.Interfaces;
using PaymentGateway.Infrastructure;
using PaymentGateway.Infrastructure.Kafka;
using PaymentGateway.Infrastructure.Kafka.Producers;
using PaymentGateway.Worker.Background;
using PaymentGateway.Worker.Consumers;
using PaymentGateway.Worker.Services;

namespace PaymentGateway.Worker;

public static class DependencyInjection
{
    public static IServiceCollection AddWorkerServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<KafkaSettings>(configuration.GetSection("Kafka"));

        services.AddInfrastructure(configuration);

        services.AddSingleton<IKafkaProducer, KafkaProducer>();

        services.AddHostedService<KafkaBackgroundService>();

        services.AddSingleton<PaymentRequestConsumer>();

        services.AddSingleton<PaymentProcessorService>();

        services.AddSingleton<CardAuthorizationService>();

        return services;
    }
}