using CreditCalculator.Models.Enums;
using CreditCalculator.Services.Interfaces;

namespace CreditCalculator.Services;

public class CreditCalculatorFactory : ICreditCalculatorFactory
{
    private readonly IServiceProvider _serviceProvider;

    public CreditCalculatorFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public ICreditCalculator GetCalculator(RateType rateType)
    {
        return rateType switch
        {
            RateType.Yearly => _serviceProvider.GetRequiredService<YearlyRateCreditCalculator>(),
            RateType.Daily  => _serviceProvider.GetRequiredService<DailyRateCreditCalculator>(),
            _        => throw new ArgumentException($"Unknown rate type: {rateType}")
        };
    }
}