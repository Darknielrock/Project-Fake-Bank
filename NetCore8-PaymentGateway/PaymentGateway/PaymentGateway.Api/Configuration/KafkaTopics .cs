namespace PaymentGateway.Api.Configuration
{
    public class KafkaTopics
    {
        public string PaymentCreated { get; set; } = string.Empty;

        public string PaymentApproved { get; set; } = string.Empty;

        public string PaymentRejected { get; set; } = string.Empty;
    }
}
