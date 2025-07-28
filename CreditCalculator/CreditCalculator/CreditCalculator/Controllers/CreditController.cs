using CreditCalculator.Models.Enums;
using CreditCalculator.Models.Form;
using CreditCalculator.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CreditCalculator.Controllers;

public class CreditController : Controller
{
    private readonly ICreditCalculatorFactory _calculatorFactory;
    private readonly ICreditParametresFactory _paramFactory;

    public CreditController(ICreditCalculatorFactory calculatorFactory,
        ICreditParametresFactory paramFactory)
    {
        _calculatorFactory = calculatorFactory;
        _paramFactory = paramFactory;
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

        var calculator = _calculatorFactory.GetCalculator(model.RateType);

        var parameters = _paramFactory.CreateParameters(model); // фабрика сама решает

        var schedule = model.PaymentType == PaymentType.Annuity
            ? calculator.CalculateAnnuitetPaymentsSchedule(parameters)
            : calculator.CalculateDifferentiatedPaymentsSchedule(parameters);

        return View("PaymentsSchedule", schedule);
    }
}