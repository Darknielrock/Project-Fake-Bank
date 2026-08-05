using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway.Infrastructure.Kafka.Models
{
    public class PaymentProcessedMessage
    {
        public Guid PaymentId { get; set; }

        public bool Approved { get; set; }

        public string AuthorizationCode { get; set; } = "";

        public string Reason { get; set; } = "";
    }
}
