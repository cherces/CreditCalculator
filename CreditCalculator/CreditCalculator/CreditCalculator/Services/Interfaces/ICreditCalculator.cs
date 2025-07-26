using CreditCalculator.Models;

namespace CreditCalculator.Services.Interfaces;

public interface ICreditCalculator
{
    List<PaymentScheduleItem> CalculateAnnuitetPaymentSchedules(CreditParametresBase creditParametres);
    List<PaymentScheduleItem> CalculateDifferentiatedPaymentSchedules(CreditParametresBase creditParametres);
}