using LoanSystem.Services;
using LoanSystem.Services.LoanStrategies;

namespace LoanSystem.Services;
public class LoanCalculationStrategyFactory : ILoanCalculationStrategyFactory
{
    public ILoanCalculationStrategy GetStrategy(int age)
    {
        if (age < 20)
        {
            return new Under20LoanCalculationStrategy();
        }
        else if (age >= 20 && age <= 35)
        {
            return new Between20And35LoanCalculationStrategy();
        }
        else
        {
            return new Above35LoanCalculationStrategy();
        }
    }
}