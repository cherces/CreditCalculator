using CreditCalculator.Models;
using CreditCalculator.Services.Interfaces;

namespace CreditCalculator.Services;

public class YearlyRateCreditCalculator : ICreditCalculator
{
    public List<PaymentScheduleItem> CalculateAnnuitetPaymentSchedules(CreditParametresBase creditParametres)
    {
        var paymentsSchedule = new List<PaymentScheduleItem>();
        
        var yearlyRateCreditParametres = creditParametres as YearlyRateCreditParametres;

        // 1. Переводим годовую ставку в месячную
        decimal i = creditParametres.Rate / 12;

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
            paymentsSchedule.Add(new PaymentScheduleItem
            {
                PaymentNumber = month,
                PaymentDate = startDate.AddMonths(month),
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