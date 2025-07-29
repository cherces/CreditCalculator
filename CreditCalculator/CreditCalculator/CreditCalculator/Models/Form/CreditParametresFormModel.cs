using System.ComponentModel.DataAnnotations;
using CreditCalculator.Models.Enums;

namespace CreditCalculator.Models.Form;

public class CreditParametersFormModel
{
    [Required]
    [Display(Name = "Тип ставки")]
    public RateType RateType { get; set; } // % ставка за "Год" или "День"
    
    [Required]
    [Display(Name = "Тип платежа")]
    public PaymentType PaymentType { get; set; } // "Аннуитетный" или "Дифференцированный"

    [Required]
    [Range(5000, 100000000)]
    [Display(Name = "Сумма кредита")]
    public decimal Amount { get; set; }
    
    [Required]
    [Range(1, 360)]
    [Display(Name = "Срок")]
    public int Term { get; set; }
    
    [Required]
    [Range(0.01, 100)]
    [Display(Name = "Размер процентной ставки")]
    public decimal Rate { get; set; }

    // Если % ставка за "День"
    [Display(Name = "Период платежей")]
    public int? StepDays { get; set; }
}