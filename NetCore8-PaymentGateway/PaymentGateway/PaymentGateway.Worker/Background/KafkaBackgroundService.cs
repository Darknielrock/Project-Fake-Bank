using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PaymentGateway.Worker.Consumers;

namespace PaymentGateway.Worker.Background;

public class KafkaBackgroundService : BackgroundService
{
    private readonly PaymentRequestConsumer _consumer;
    private readonly ILogger<KafkaBackgroundService> _logger;


    public KafkaBackgroundService(
        PaymentRequestConsumer consumer,
        ILogger<KafkaBackgroundService> logger)
    {
        _consumer = consumer;
        _logger = logger;
    }


    protected override async Task ExecuteAsync(
        CancellationToken stoppingToken)
    {
        _logger.LogInformation(
            "Payment Worker iniciado");


        while (!stoppingToken.IsCancellationRequested)
        {
            await _consumer.ConsumeAsync(
                stoppingToken);
        }
    }
}