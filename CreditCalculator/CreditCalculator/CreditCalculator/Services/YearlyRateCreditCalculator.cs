using CreditCalculator.Models;
using CreditCalculator.Services.Interfaces;

namespace CreditCalculator.Services;

public class YearlyRateCreditCalculator : ICreditCalculator
{
    public List<PaymentScheduleItem> CalculateAnnuitetPaymentSchedules(CreditParametresBase creditParametres)
    {
        throw new NotImplementedException();
    }

    public List<PaymentScheduleItem> CalculateDifferentiatedPaymentSchedules(CreditParametresBase creditParametres)
    {
        throw new NotImplementedException();
    }
}