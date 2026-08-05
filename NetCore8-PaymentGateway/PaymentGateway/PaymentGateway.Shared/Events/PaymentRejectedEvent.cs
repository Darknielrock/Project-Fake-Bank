using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway.Shared.Events
{
    public class PaymentRejectedEvent
    {
        public Guid PaymentId { get; set; }

        public string RejectionReason { get; set; } = string.Empty;
    }
}
