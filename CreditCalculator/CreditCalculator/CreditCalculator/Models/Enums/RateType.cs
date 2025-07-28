using System.ComponentModel.DataAnnotations;

namespace CreditCalculator.Models.Enums;

public enum RateType
{
    [Display(Name = "Годовая")]
    Yearly = 1,
    
    [Display(Name = "Дневная")]
    Daily = 2
}