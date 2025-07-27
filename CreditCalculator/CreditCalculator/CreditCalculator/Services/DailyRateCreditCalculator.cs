using CreditCalculator.Models;
using CreditCalculator.Services.Interfaces;

namespace CreditCalculator.Services;

public class DailyRateCreditCalculator : ICreditCalculator
{
    public List<PaymentScheduleItem> CalculateAnnuitetPaymentSchedules(CreditParametresBase creditParametres)
    {
        var paymentsSchedule = new List<PaymentScheduleItem>();
        
        var dailyRateCreditParametres = creditParametres as DailyRateCreditParametres;

        // 1. Количество платежей
        int n = (int)Math.Ceiling((double)dailyRateCreditParametres.Term / dailyRateCreditParametres.StepDays);

        // 2. Ставка за один шаг
        decimal i = dailyRateCreditParametres.Rate * dailyRateCreditParametres.StepDays;

        // 3. Аннуитетный коэффициент K
        decimal k = (i * (decimal)Math.Pow(1 + (double)i, n))
                    / ((decimal)Math.Pow(1 + (double)i, n) - 1);

        // 4. Размер платежа
        decimal stepPayment = dailyRateCreditParametres.Amount * k;

        // 5. Остаток долга
        decimal debt =  dailyRateCreditParametres.Amount;

        DateTime date = DateTime.Today;

        for (int step = 1; step <= n; step++)
        {
            // 6. Процентная часть(p_n) = остаток долга * дневную ставку
            decimal interest = debt * dailyRateCreditParametres.Rate * dailyRateCreditParametres.StepDays;

            // 7. Основная часть(s) = платеж - процентная часть платежа
            decimal principal = stepPayment - interest;

            // 8. Уменьшаем долг
            debt -= principal;
            if (debt < 0) debt = 0;

            // 9. Добавляем платеж в график
            paymentsSchedule.Add(new PaymentScheduleItem
            {
                PaymentNumber = step,
                PaymentDate = date.AddDays(step * dailyRateCreditParametres.StepDays),
                PrincipalAmount = Math.Round(principal, 2),
                InterestAmount = Math.Round(interest, 2),
                DebtAmount = Math.Round(debt, 2)
            });
        }

        return paymentsSchedule;
    }

    public List<PaymentScheduleItem> CalculateDifferentiatedPaymentSchedules(CreditParametresBase creditParametres)
    {
        throw new NotImplementedException();
    }
}