using CreditCalculator.Models;
using CreditCalculator.Models.Enums;
using CreditCalculator.Models.Form;

namespace CreditCalculator.Services.Helpers;

public static class CreditParametersMapper
{
    public static CreditParametersBase Map(CreditParametersFormModel model)
    {
        return model.RateType switch
        {
            RateType.Yearly => new YearlyRateCreditParameters
            {
                Amount = model.Amount,
                Term = model.Term,
                Rate = model.Rate,
                PaymentType = model.PaymentType
            },
            RateType.Daily => new DailyRateCreditParameters
            {
                Amount = model.Amount,
                Term = model.Term,
                Rate = model.Rate,
                StepDays = model.StepDays ?? 30,
                PaymentType = model.PaymentType
            },
            _ => throw new ArgumentException("Unsupported rate type")
        };
    }
}