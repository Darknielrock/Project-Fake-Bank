using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway.Shared.Constants;

public static class KafkaTopics
{
    public const string PaymentRequested = "payment-request";

    public const string PaymentProcessed = "payment-processed";
}
