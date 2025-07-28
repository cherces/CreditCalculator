using CreditCalculator.Models;
using CreditCalculator.Models.Enums;
using CreditCalculator.Models.Form;
using CreditCalculator.Services.Interfaces;

namespace CreditCalculator.Services;

public class CreditParametresFactory :ICreditParametresFactory
{
    public CreditParametresBase CreateParameters(CreditParametresFormModel model)
    {
        return model.RateType switch
        {
            RateType.Yearly => new YearlyRateCreditParametres
            {
                Amount = model.Amount,
                Term = model.Term,
                Rate = model.Rate,
                PaymentType = model.PaymentType
            },
            RateType.Daily => new DailyRateCreditParametres
            {
                Amount = model.Amount,
                Term = model.Term,
                Rate = model.Rate,
                StepDays = model.StepDays ?? 30,
                PaymentType = model.PaymentType
            },
            _ => throw new ArgumentException("Unknown rate type")
        };
    }
}