using Confluent.Kafka;
using Microsoft.Extensions.Options;
using PaymentGateway.Domain.Entities;
using PaymentGateway.Infrastructure.Kafka;
using PaymentGateway.Shared.Events;
using System.Text.Json;
using PaymentGateway.Application.Common.Interfaces;

namespace PaymentGateway.Infrastructure.Kafka.Producers
{
    public class KafkaProducer : IKafkaProducer
    {
        private readonly IProducer<string, string> _producer;
        private readonly KafkaSettings _settings;

        public KafkaProducer(IOptions<KafkaSettings> options)
        {
            _settings = options.Value;

            var config = new ProducerConfig
            {
                BootstrapServers = _settings.BootstrapServers
            };

            _producer = new ProducerBuilder<string, string>(config)
                .Build();
        }

        public async Task PublishPaymentRequestAsync(Payment payment, CancellationToken cancellationToken)
        {
            var message = new PaymentRequestedEvent
            {
                PaymentId = payment.Id,
                Amount = payment.Amount,
                Currency = payment.Currency,
                CardHolder = payment.CardHolder,
                CardNumberMasked = payment.CardNumberMasked
            };

            var json = JsonSerializer.Serialize(message);

            await _producer.ProduceAsync(
                _settings.Topics.PaymentCreated,
                new Message<string, string>
                {
                    Key = payment.Id.ToString(),
                    Value = json
                },
                cancellationToken);
        }

        public async Task ProcessPaymentApprovedAsync(PaymentApprovedEvent paymentApproved,CancellationToken cancellationToken)
        {
            var json = JsonSerializer.Serialize(paymentApproved);

            await _producer.ProduceAsync(
                _settings.Topics.PaymentApproved,
                new Message<string, string>
                {
                    Key = paymentApproved.PaymentId.ToString(),
                    Value = json
                },
                cancellationToken);
        }

        public async Task ProcessPaymentRejectedAsync(PaymentRejectedEvent paymentRejected, CancellationToken cancellationToken)
        {
            var json = JsonSerializer.Serialize(paymentRejected);

            await _producer.ProduceAsync(
                _settings.Topics.PaymentRejected,
                new Message<string, string>
                {
                    Key = paymentRejected.PaymentId.ToString(),
                    Value = json
                },
                cancellationToken);
        }
        
    }
}