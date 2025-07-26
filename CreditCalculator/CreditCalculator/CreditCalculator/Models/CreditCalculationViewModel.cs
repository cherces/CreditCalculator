using System.ComponentModel.DataAnnotations;

namespace CreditCalculator.Models;

public class CreditCalculationViewModel
{
    [Required]
    public string RateType { get; set; } // % ставка за "Год" или "День"
    
    [Required]
    public string PaymentType { get; set; } // "Аннуитетный" или "Дифференцированный"

    [Required]
    [Range(5000, 100000000)]
    public decimal Amount { get; set; }
    
    [Required]
    [Range(1, 360)]
    public int Term { get; set; }
    
    [Required]
    [Range(0.01, 100)]
    public decimal Rate { get; set; }

    // Для % ставки за День
    public int? StepDays { get; set; }
}