using CreditCalculator.Services;
using CreditCalculator.Services.Interfaces;

namespace CreditCalculator.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCreditCalculatorServices(this IServiceCollection services)
    {
        services.AddScoped<ICreditCalculatorFactory, CreditCalculatorFactory>();
        services.AddScoped<ICreditParametresFactory, CreditParametresFactory>();
        
        services.AddScoped<YearlyRateCreditCalculator>();
        services.AddScoped<DailyRateCreditCalculator>();

        return services;
    }
}