using CreditCalculator.Services;
using CreditCalculator.Services.Interfaces;

namespace CreditCalculator.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCreditCalculatorServices(this IServiceCollection services)
    {
        services.AddSingleton<ICreditCalculatorFactory, CreditCalculatorFactory>();
        services.AddSingleton<ICreditParametersFactory, CreditParametersFactory>();
        
        services.AddSingleton<YearlyRateCreditCalculator>();
        services.AddSingleton<DailyRateCreditCalculator>();
        
        services.AddSingleton<ICreditCalculationService, CreditCalculationService>();

        return services;
    }
}