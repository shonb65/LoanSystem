namespace LoanSystem.Services;
public interface ILoanService
{
    void SetCalculator(ILoanCalculationStrategy strategy);
    decimal CalculateTotalAmount(decimal amount, int periodInMonths);
}
