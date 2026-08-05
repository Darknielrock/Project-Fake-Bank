using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using PaymentGateway.Infrastructure.Kafka;
using PaymentGateway.Infrastructure.Kafka.Producers;
using PaymentGateway.Application.Common.Interfaces;

namespace PaymentGateway.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<PaymentDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")));

            services.Configure<KafkaSettings>(
                configuration.GetSection("Kafka"));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IPaymentRepository, PaymentRepository>();

            services.AddSingleton<IKafkaProducer, KafkaProducer>();

            return services;
        }
    }
}
