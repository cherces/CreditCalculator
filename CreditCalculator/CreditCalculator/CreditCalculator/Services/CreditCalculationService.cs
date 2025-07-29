using CreditCalculator.Models;
using CreditCalculator.Models.Enums;
using CreditCalculator.Models.Form;
using CreditCalculator.Services.Helpers;
using CreditCalculator.Services.Interfaces;

namespace CreditCalculator.Services;

public class CreditCalculationService : ICreditCalculationService
{
    private readonly ICreditCalculatorFactory _calculatorFactory;

    public CreditCalculationService(ICreditCalculatorFactory calculatorFactory)
    {
        _calculatorFactory = calculatorFactory;
    }

    public CreditCalculateResultViewModel Calculate(CreditParametersFormModel model)
    {
        var parameters = CreditParametersMapper.Map(model);
        var calculator = _calculatorFactory.GetCalculator(model.RateType);

        var schedule = model.PaymentType switch
        {
            PaymentType.Annuity => calculator.CalculateAnnuitetPaymentsSchedule(parameters),
            PaymentType.Differentiated => calculator.CalculateDifferentiatedPaymentsSchedule(parameters),
            _ => throw new NotSupportedException("Unknown payment type")
        };
        
        var totalPayment = schedule.Sum(p => p.Amount);
        var overpayment = totalPayment - parameters.Amount;

        return new CreditCalculateResultViewModel
        {
            Schedule = schedule,
            TotalPayment = Math.Round(totalPayment, 2),
            Overpayment = Math.Round(overpayment, 2)
        };
    }
}