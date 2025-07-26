namespace CreditCalculator.Models;

public abstract class CreditParametresBase
{
    public decimal Amount { get; set; }
    public decimal Rate { get; set; }
    public string PaymentType { get; set; }
}