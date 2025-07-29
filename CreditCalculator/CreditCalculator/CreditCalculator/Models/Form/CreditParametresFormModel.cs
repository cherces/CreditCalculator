using System.ComponentModel.DataAnnotations;
using CreditCalculator.Models.Enums;

namespace CreditCalculator.Models.Form;

public class CreditParametersFormModel
{
    [Required]
    public RateType RateType { get; set; } // % ставка за "Год" или "День"
    
    [Required]
    public PaymentType PaymentType { get; set; } // "Аннуитетный" или "Дифференцированный"

    [Required]
    [Range(5000, 100000000)]
    public decimal Amount { get; set; }
    
    [Required]
    [Range(1, 360)]
    public int Term { get; set; }
    
    [Required]
    [Range(0.01, 100)]
    public decimal Rate { get; set; }

    // Если % ставка за "День"
    public int? StepDays { get; set; }
}