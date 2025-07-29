using CreditCalculator.Models;
using CreditCalculator.Models.Form;

namespace CreditCalculator.Services.Interfaces;

public interface ICreditParametersFactory
{
    CreditParametersBase CreateParameters(CreditParametersFormModel formModel);
}