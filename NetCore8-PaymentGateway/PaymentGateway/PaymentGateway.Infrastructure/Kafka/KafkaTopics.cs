namespace PaymentGateway.Infrastructure.Kafka
{
    public class KafkaTopics
    {
        public string PaymentCreated { get; set; } = string.Empty;

        public string PaymentApproved { get; set; } = string.Empty;

        public string PaymentRejected { get; set; } = string.Empty;
    }
}
