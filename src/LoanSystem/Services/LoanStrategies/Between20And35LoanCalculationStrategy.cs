
namespace LoanSystem.Services.LoanStrategies;

public class Between20And35LoanCalculationStrategy : ILoanCalculationStrategy
{
    public decimal CalculateLoanAmount(decimal amount)
    {
        if (amount <= 5000)
        {
            return (0.02m * amount);
        }
        else if (amount <= 30000)
        {
            return (0.015m * amount) + (LoanConstants.LoanConstants.PrimeInterestRate * amount);
        }
        else
        {
            return (0.01m * amount) + (LoanConstants.LoanConstants.PrimeInterestRate * amount);
        }
    }
}