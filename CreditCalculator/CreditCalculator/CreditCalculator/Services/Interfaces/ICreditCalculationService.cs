using CreditCalculator.Models;
using CreditCalculator.Models.Form;

namespace CreditCalculator.Services.Interfaces;

public interface ICreditCalculationService
{
    IReadOnlyList<PaymentsScheduleItem> Calculate(CreditParametresFormModel model);
}