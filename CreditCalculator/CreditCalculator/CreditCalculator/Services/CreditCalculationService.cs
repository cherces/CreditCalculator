using CreditCalculator.Models;
using CreditCalculator.Models.Enums;
using CreditCalculator.Models.Form;
using CreditCalculator.Services.Interfaces;

namespace CreditCalculator.Services;

public class CreditCalculationService : ICreditCalculationService
{
    private readonly ICreditParametresFactory _paramFactory;
    private readonly ICreditCalculatorFactory _calculatorFactory;

    public CreditCalculationService(
        ICreditParametresFactory paramFactory,
        ICreditCalculatorFactory calculatorFactory)
    {
        _paramFactory = paramFactory;
        _calculatorFactory = calculatorFactory;
    }

    public IReadOnlyList<PaymentsScheduleItem> Calculate(CreditParametresFormModel model)
    {
        var parameters = _paramFactory.CreateParameters(model);
        var calculator = _calculatorFactory.GetCalculator(model.RateType);

        return model.PaymentType switch
        {
            PaymentType.Annuity => calculator.CalculateAnnuitetPaymentsSchedule(parameters),
            PaymentType.Differentiated => calculator.CalculateDifferentiatedPaymentsSchedule(parameters),
            _ => throw new NotSupportedException("Unknown payment type")
        };
    }
}