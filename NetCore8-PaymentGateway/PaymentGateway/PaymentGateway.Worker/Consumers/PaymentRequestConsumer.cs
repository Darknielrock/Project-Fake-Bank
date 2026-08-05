using Confluent.Kafka;
using Microsoft.Extensions.Options;
using PaymentGateway.Infrastructure.Kafka;
using PaymentGateway.Shared.Events;
using PaymentGateway.Worker.Services;
using System.Text.Json;

namespace PaymentGateway.Worker.Consumers;

public class PaymentRequestConsumer
{
    private readonly PaymentProcessorService _processor;
    private readonly IConsumer<string, string> _consumer;


    public PaymentRequestConsumer(
        IOptions<KafkaSettings> options,
        PaymentProcessorService processor)
    {
        _processor = processor;

        var config = new ConsumerConfig
        {
            BootstrapServers = options.Value.BootstrapServers,
            GroupId = "payment-worker",
            AutoOffsetReset = AutoOffsetReset.Earliest
        };

        _consumer = new ConsumerBuilder<string, string>(config)
            .Build();

        _consumer.Subscribe(options.Value.Topics.PaymentCreated);
    }


    public async Task ConsumeAsync(
        CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            var result = _consumer.Consume(cancellationToken);

            if (result == null)
                continue;

            var payment = JsonSerializer.Deserialize<PaymentRequestedEvent>(
                result.Message.Value);

            if (payment == null)
                continue;

            await _processor.ProcessAsync(
                payment,
                cancellationToken);
        }
    }
}