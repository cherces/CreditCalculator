namespace CreditCalculator.Models;

public class PaymentsScheduleItem
{
    public int PaymentNumber { get; set; }
    public DateTime PaymentDate { get; set; }
    public decimal Amount { get; set; }
    public decimal PrincipalAmount { get; set; }
    public decimal InterestAmount { get; set; }
    public decimal DebtAmount { get; set; }
}