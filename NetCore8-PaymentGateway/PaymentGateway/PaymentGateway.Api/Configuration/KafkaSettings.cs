using PaymentGateway.Shared.Constants;

namespace PaymentGateway.Api.Configuration
{
    public class KafkaSettings
    {
        public string BootstrapServers { get; set; } = string.Empty;

        public KafkaTopics Topics { get; set; } = new();
    }
}
