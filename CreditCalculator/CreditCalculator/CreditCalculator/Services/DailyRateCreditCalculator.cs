using CreditCalculator.Models;
using CreditCalculator.Services.Interfaces;

namespace CreditCalculator.Services;

public class DailyRateCreditCalculator : ICreditCalculator
{
    public IReadOnlyList<PaymentsScheduleItem> CalculateAnnuitetPaymentsSchedule(CreditParametersBase creditParametres)
    {
        var paymentsSchedule = new List<PaymentsScheduleItem>();
        
        var dailyRateCreditParametres = creditParametres as DailyRateCreditParameters;

        // 1. Количество платежей
        int n = (int)Math.Ceiling((double)dailyRateCreditParametres.Term / dailyRateCreditParametres.StepDays);

        // 2. Ставка за один шаг
        decimal i = (dailyRateCreditParametres.Rate / 100) * dailyRateCreditParametres.StepDays;

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
            decimal interest = debt * (dailyRateCreditParametres.Rate / 100) * dailyRateCreditParametres.StepDays;

            // 7. Основная часть(s) = платеж - процентная часть платежа
            decimal principal = stepPayment - interest;

            // 8. Уменьшаем долг
            debt -= principal;
            if (debt < 0) debt = 0;

            // 9. Добавляем платеж в график
            paymentsSchedule.Add(new PaymentsScheduleItem
            {
                PaymentNumber = step,
                PaymentDate = date.AddDays(step * dailyRateCreditParametres.StepDays),
                Amount = Math.Round(principal + interest, 2),
                PrincipalAmount = Math.Round(principal, 2),
                InterestAmount = Math.Round(interest, 2),
                DebtAmount = Math.Round(debt, 2)
            });
        }

        return paymentsSchedule;
    }

    public IReadOnlyList<PaymentsScheduleItem> CalculateDifferentiatedPaymentsSchedule(CreditParametersBase creditParametres)
    {
        var paymentsSchedule = new List<PaymentsScheduleItem>();
        
        var dailyRateCreditParametres = creditParametres as DailyRateCreditParameters;

        // Количество платежей
        int n = (int)Math.Ceiling((decimal)dailyRateCreditParametres.Term / dailyRateCreditParametres.StepDays);

        // Фиксированная часть тела кредита
        decimal principal = dailyRateCreditParametres.Amount / n;

        DateTime startDate = DateTime.Today;

        for (int p = 1; p <= n; p++)
        {
            // Остаток долга до платежа
            decimal debt = dailyRateCreditParametres.Amount - principal * (p - 1);

            // Количество дней в этом платёжном периоде
            int days = (p == n) 
                ? dailyRateCreditParametres.Term - dailyRateCreditParametres.StepDays * (p - 1) // последний период может быть короче
                : dailyRateCreditParametres.StepDays;

            // Проценты за этот период
            decimal interest = debt * (dailyRateCreditParametres.Rate / 100) * days;

            // Новый остаток долга
            decimal newDebt = debt - principal;

            paymentsSchedule.Add(new PaymentsScheduleItem
            {
                PaymentNumber = p,
                PaymentDate = startDate.AddDays(p * dailyRateCreditParametres.StepDays),
                Amount = Math.Round(principal + interest, 2),
                PrincipalAmount = Math.Round(principal, 2),
                InterestAmount = Math.Round(interest, 2),
                DebtAmount = Math.Round(Math.Max(newDebt, 0), 2)
            });
        }

        return paymentsSchedule;
    }
}