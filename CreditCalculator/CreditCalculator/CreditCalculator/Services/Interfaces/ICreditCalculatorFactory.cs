using CreditCalculator.Models.Enums;

namespace CreditCalculator.Services.Interfaces;

public interface ICreditCalculatorFactory
{
    ICreditCalculator GetCalculator(RateType rateType);
}