using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway.Infrastructure.Kafka.Models
{
    public class PaymentRequestMessage
    {
        public Guid PaymentId { get; set; }

        public decimal Amount { get; set; }

        public string Currency { get; set; } = "";

        public string CardHolder { get; set; } = "";
    }
}
