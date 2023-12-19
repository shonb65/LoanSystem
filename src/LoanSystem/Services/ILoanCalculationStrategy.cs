using LoanSystem.Models;

namespace LoanSystem.Services;
public interface ILoanCalculationStrategy
{
     decimal CalculateLoanAmount(decimal amount);
}