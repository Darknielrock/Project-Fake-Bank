using FluentValidation;

namespace PaymentGateway.Application.Payments.Commands.CreatePayment;

public sealed class CreatePaymentValidator
    : AbstractValidator<CreatePaymentCommand>
{
    public CreatePaymentValidator()
    {
        RuleFor(x => x.Amount)
            .GreaterThan(0)
            .WithMessage("El monto debe ser mayor que cero.");

        RuleFor(x => x.Currency)
            .NotEmpty()
            .Length(3)
            .WithMessage("La moneda debe tener 3 caracteres.");

        RuleFor(x => x.CardHolder)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.CardNumber)
            .CreditCard()
            .WithMessage("Número de tarjeta inválido.");

        RuleFor(x => x.Cvv)
            .Matches(@"^\d{3,4}$")
            .WithMessage("CVV inválido.");

        RuleFor(x => x.ExpirationMonth)
            .InclusiveBetween("01", "12");

        RuleFor(x => x.ExpirationYear)
            .Matches(@"^\d{4}$")
            .WithMessage("Año inválido.");
    }
}