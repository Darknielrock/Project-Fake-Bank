using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway.Shared.Constants
{
    public static class ErrorMessages
    {
        public const string PaymentNotFound =
            "No se encontró el pago.";

        public const string InvalidCard =
            "La tarjeta es inválida.";

        public const string PaymentRejected =
            "El pago fue rechazado.";
    }
}
