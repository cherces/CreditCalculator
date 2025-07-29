namespace CreditCalculator.Models;

public class CreditCalculateResultViewModel
{
    public IReadOnlyList<PaymentsScheduleItem> Schedule { get; set; }
    public decimal TotalPayment { get; set; }
    public decimal Overpayment { get; set; }
}