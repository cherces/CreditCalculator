using CreditCalculator.Models.Enums;
using CreditCalculator.Models.Form;
using CreditCalculator.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CreditCalculator.Controllers;

public class CreditController : Controller
{
    private readonly ICreditCalculationService _calculationService;

    public CreditController(ICreditCalculationService calculationService)
    {
        _calculationService = calculationService;
    }

    [HttpGet]
    public IActionResult Calculator()
    {
        return View(new CreditParametresFormModel());
    }

    [HttpPost]
    public IActionResult Calculator(CreditParametresFormModel model)
    {
        if (!ModelState.IsValid)
            return View(model);
        
        if (model.RateType == RateType.Daily && (!model.StepDays.HasValue || model.StepDays <= 0))
        {
            ModelState.AddModelError("StepDays", "Для дневной ставки нужно указать период платежа больше 0.");
            return View(model);
        }

        var schedule = _calculationService.Calculate(model);

        return View("PaymentsSchedule", schedule);
    }
}