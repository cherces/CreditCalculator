using CreditCalculator.Models;

namespace CreditCalculator.Services.Interfaces;

public interface ICreditCalculator
{
    List<PaymentsScheduleItem> CalculateAnnuitetPaymentsSchedule(CreditParametresBase creditParametres);
    List<PaymentsScheduleItem> CalculateDifferentiatedPaymentsSchedule(CreditParametresBase creditParametres);
}