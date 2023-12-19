using LoanSystem.LoanConstants;

namespace LoanSystem.Services.LoanStrategies;

public class Above35LoanCalculationStrategy : ILoanCalculationStrategy
{
    public decimal CalculateLoanAmount(decimal amount)
    {
        if (amount <= 15000)
        {
            return (0.015m * amount) + (LoanConstants.LoanConstants.PrimeInterestRate * amount);
        }
        else if (amount <= 30000)
        {
            return (0.03m * amount) + (LoanConstants.LoanConstants.PrimeInterestRate * amount);
        }
        else
        {
            return 0.01m * amount;
        }
    }
}