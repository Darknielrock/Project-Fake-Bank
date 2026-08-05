using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway.Shared.Events
{
    public class PaymentRequestedEvent
    {
        public Guid PaymentId { get; set; }

        public decimal Amount { get; set; }

        public string Currency { get; set; } = string.Empty;

        public string CardHolder { get; set; } = string.Empty;

        public string CardNumberMasked { get; set; } = string.Empty;
    }
}
