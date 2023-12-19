namespace LoanSystem.Services;

public class LoanService : ILoanService
{
    private ILoanCalculationStrategy _strategy;

    public LoanService(ILoanCalculationStrategy strategy)
    {
        _strategy = strategy;
    }

    public void SetCalculator(ILoanCalculationStrategy strategy) => _strategy = strategy;

    public decimal CalculateTotalAmount(decimal amount, int periodInMonths)
    {
        decimal basicInterest = _strategy.CalculateLoanAmount(amount);
        decimal extraMonthInterest = 0.0015m * amount * (periodInMonths - 12);

        return amount + basicInterest + extraMonthInterest;
    }
}