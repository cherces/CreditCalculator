using CreditCalculator.Models;
using CreditCalculator.Models.Form;

namespace CreditCalculator.Services.Interfaces;

public interface ICreditParametresFactory
{
    CreditParametresBase CreateParameters(CreditParametresFormModel formModel);
}