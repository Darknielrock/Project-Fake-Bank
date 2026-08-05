using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PaymentGateway.Application.Common.Behaviors;

namespace PaymentGateway.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(
            this IServiceCollection services)
        {
            // Register MediatR handlers from this assembly
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));

            // Register FluentValidation validators
            // Register specific validators explicitly to avoid extra package dependency
            services.AddTransient<FluentValidation.IValidator<Payments.Commands.CreatePayment.CreatePaymentCommand>, Payments.Commands.CreatePayment.   CreatePaymentValidator>();

            // Register pipeline behaviors
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            return services;
        }
    }
}
