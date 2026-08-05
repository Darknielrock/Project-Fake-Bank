using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway.Shared.Helpers
{
    public static class CardMaskHelper
    {
        public static string Mask(string cardNumber)
        {
            if (string.IsNullOrWhiteSpace(cardNumber))
                return string.Empty;

            if (cardNumber.Length < 10)
                return "****";

            return $"{cardNumber[..6]}******{cardNumber[^4..]}";
        }
    }
}
