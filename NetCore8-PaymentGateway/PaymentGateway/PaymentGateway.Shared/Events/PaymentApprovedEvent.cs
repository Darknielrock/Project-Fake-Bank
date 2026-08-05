using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway.Shared.Events
{
    public class PaymentApprovedEvent
    {
        public Guid PaymentId { get; set; }

        public string AuthorizationCode { get; set; } = string.Empty;
    }
}
