namespace CreditCalculator.Models;

public class DailyRateCreditParameters : CreditParametersBase
{
    public int Term { get; set; }
    public int StepDays { get; set; }
}