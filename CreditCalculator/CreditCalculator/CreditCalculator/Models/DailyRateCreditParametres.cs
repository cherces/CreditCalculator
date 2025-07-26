namespace CreditCalculator.Models;

public class DailyRateCreditParametres : CreditParametresBase
{
    public int Term { get; set; }
    public int StepDays { get; set; }
}