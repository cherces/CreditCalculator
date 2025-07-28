using CreditCalculator.Models;

namespace CreditCalculator.Services.Interfaces;

public interface ICreditCalculator
{
    IReadOnlyList<PaymentsScheduleItem> CalculateAnnuitetPaymentsSchedule(CreditParametresBase creditParametres);
    IReadOnlyList<PaymentsScheduleItem> CalculateDifferentiatedPaymentsSchedule(CreditParametresBase creditParametres);
}