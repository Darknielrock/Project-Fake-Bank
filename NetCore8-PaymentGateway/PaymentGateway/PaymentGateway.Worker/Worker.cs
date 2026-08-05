using PaymentGateway.Worker.Consumers;

namespace PaymentGateway.Worker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly PaymentRequestConsumer _consumer;

        public Worker(
            ILogger<Worker> logger,
            PaymentRequestConsumer consumer)
        {
            _logger = logger;
            _consumer = consumer;
        }

        protected override async Task ExecuteAsync(
            CancellationToken stoppingToken)
        {
            _logger.LogInformation("Payment Worker iniciado.");

            await _consumer.ConsumeAsync(stoppingToken);

        }
    }
}
