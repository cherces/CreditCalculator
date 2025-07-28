using CreditCalculator.Services;
using CreditCalculator.Services.Interfaces;

namespace CreditCalculator.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCreditCalculatorServices(this IServiceCollection services)
    {
        services.AddScoped<ICreditCalculatorFactory, CreditCalculatorFactory>();
        services.AddScoped<ICreditParametresFactory, CreditParametresFactory>();
        
        services.AddSingleton<YearlyRateCreditCalculator>();
        services.AddSingleton<DailyRateCreditCalculator>();
        
        services.AddScoped<ICreditCalculationService, CreditCalculationService>();

        return services;
    }
}