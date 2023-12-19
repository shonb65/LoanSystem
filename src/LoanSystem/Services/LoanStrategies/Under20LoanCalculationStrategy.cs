
using LoanSystem.LoanConstants;
namespace LoanSystem.Services.LoanStrategies;

public class Under20LoanCalculationStrategy : ILoanCalculationStrategy
{
    public decimal CalculateLoanAmount(decimal amount) => (0.02m * amount) + (LoanConstants.LoanConstants.PrimeInterestRate * amount);
}