using CreditCalculator.Models;
using CreditCalculator.Services.Interfaces;

namespace CreditCalculator.Services;

public class YearlyRateCreditCalculator : ICreditCalculator
{
    public IReadOnlyList<PaymentsScheduleItem> CalculateAnnuitetPaymentsSchedule(CreditParametersBase creditParametres)
    {
        var paymentsSchedule = new List<PaymentsScheduleItem>();
        
        var yearlyRateCreditParametres = creditParametres as YearlyRateCreditParameters;

        // 1. Переводим годовую ставку в месячную
        decimal i = (creditParametres.Rate / 100) / 12;

        // 2. Вычисляем аннуитетный коэффициент K
        decimal k = (i * (decimal)Math.Pow(1 + (double)i, yearlyRateCreditParametres.Term))
                    / ((decimal)Math.Pow(1 + (double)i, yearlyRateCreditParametres.Term) - 1);

        // 3. Ежемесячный платеж A
        decimal monthlyPayment = yearlyRateCreditParametres.Amount * k;

        // 4. Остаток долга
        decimal debt = yearlyRateCreditParametres.Amount;

        DateTime startDate = DateTime.Today;

        for (int month = 1; month <= yearlyRateCreditParametres.Term; month++)
        {
            // 5. Процентная часть (p_n) = остаток долга * месячную ставку
            decimal interest = debt * i;

            // 6. Основная часть (s) = месячный платеж - процентная часть платежа
            decimal principal = monthlyPayment - interest;

            // 7. Уменьшаем остаток
            debt -= principal;
            if (debt < 0) debt = 0;

            // 8. Добавляем платеж в график
            paymentsSchedule.Add(new PaymentsScheduleItem
            {
                PaymentNumber = month,
                PaymentDate = startDate.AddMonths(month),
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
        
        var yearlyRateCreditParametres = creditParametres as YearlyRateCreditParameters;
        
        // Переводим годовую ставку в месячную
        decimal i = (yearlyRateCreditParametres.Rate / 100) / 12;
        
        decimal principal = yearlyRateCreditParametres.Amount / yearlyRateCreditParametres.Term;
        
        DateTime startDate = DateTime.Today;
        
        for (int month = 1; month <= yearlyRateCreditParametres.Term; month++)
        {
            // Проценты за текущий месяц = остаток долга * месячную ставку
            decimal interest = (yearlyRateCreditParametres.Amount - principal * (month - 1)) * i;

            // Остаток долга после внесения платежа
            decimal debt = yearlyRateCreditParametres.Amount - principal * month;

            // Добавляем платеж в график платежей
            paymentsSchedule.Add(new PaymentsScheduleItem
            {
                PaymentNumber = month,
                PaymentDate = startDate.AddMonths(month),
                Amount = Math.Round(principal + interest, 2),
                PrincipalAmount = Math.Round(principal, 2),
                InterestAmount = Math.Round(interest, 2),
                DebtAmount = Math.Round(Math.Max(debt, 0), 2)
            });
        }
        
        return paymentsSchedule;
    }
}