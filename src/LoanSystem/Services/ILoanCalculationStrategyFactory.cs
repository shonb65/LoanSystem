using LoanSystem.Services;

namespace LoanSystem.Services;
public interface ILoanCalculationStrategyFactory
{
    ILoanCalculationStrategy GetStrategy(int age);
}