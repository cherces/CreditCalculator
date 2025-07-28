using System.ComponentModel.DataAnnotations;

namespace CreditCalculator.Models.Enums;

public enum PaymentType
{
    [Display(Name = "Аннуитетный")]
    Annuity = 1,
    
    [Display(Name = "Дифференцированный")]
    Differentiated = 2
}