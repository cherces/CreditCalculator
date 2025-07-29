using CreditCalculator.Models;

namespace CreditCalculator.Services.Interfaces;

public interface ICreditCalculator
{
    IReadOnlyList<PaymentsScheduleItem> CalculateAnnuitetPaymentsSchedule(CreditParametersBase creditParametres);
    IReadOnlyList<PaymentsScheduleItem> CalculateDifferentiatedPaymentsSchedule(CreditParametersBase creditParametres);
}