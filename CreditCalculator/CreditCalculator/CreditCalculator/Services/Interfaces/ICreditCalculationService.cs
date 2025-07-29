using CreditCalculator.Models;
using CreditCalculator.Models.Form;

namespace CreditCalculator.Services.Interfaces;

public interface ICreditCalculationService
{
    CreditCalculateResultViewModel Calculate(CreditParametersFormModel model);
}