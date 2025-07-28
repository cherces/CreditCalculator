using CreditCalculator.Models;

namespace CreditCalculator.Services.Interfaces;

public interface ICreditCalculator
{
    List<PaymentScheduleItem> CalculateAnnuitetPaymentsSchedule(CreditParametresBase creditParametres);
    List<PaymentScheduleItem> CalculateDifferentiatedPaymentsSchedule(CreditParametresBase creditParametres);
}