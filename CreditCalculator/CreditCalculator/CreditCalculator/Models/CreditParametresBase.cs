using CreditCalculator.Models.Enums;

namespace CreditCalculator.Models;

public abstract class CreditParametersBase
{
    public decimal Amount { get; set; }
    public decimal Rate { get; set; }
    public PaymentType PaymentType { get; set; }
}