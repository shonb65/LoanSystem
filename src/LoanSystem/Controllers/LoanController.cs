using LoanSystem.Dtos;
using Microsoft.AspNetCore.Mvc;
using LoanSystem.Services;
using LoanSystem.Models;
using LoanSystem.Repository;

[ApiController]
[Route("api/[controller]")]
public class LoanController : ControllerBase
{
    private readonly ILoanCalculationStrategyFactory _strategyFactory;
    private readonly ILoanService _loanService;
    private readonly IRepository<User> _userRepository;

    public LoanController(ILoanService loanService, ILoanCalculationStrategyFactory strategyFactory, IRepository<User> userRepository)
    {
        _loanService = loanService;
        _strategyFactory = strategyFactory;
        _userRepository = userRepository;
    }

    [HttpPost("calculate")]
    public async Task<ActionResult<decimal>> CalculateLoanAmount([FromBody] LoanRequestDto loanRequestDto)
    {
        try
        {
            if (loanRequestDto.Period < 12)
            {
                return BadRequest("The minimum loan period is 12 months.");
            }
            var userEntity = await _userRepository.GetByIdAsync(loanRequestDto.ClientId);

            if (userEntity == null)
            {
                return NotFound("User not found");
            }

            var strategy = _strategyFactory.GetStrategy(userEntity.Age);
            _loanService.SetCalculator(strategy);
            decimal totalAmount = _loanService.CalculateTotalAmount(loanRequestDto.Amount, loanRequestDto.Period);
            return Ok(totalAmount);
        }
        catch (Exception ex)
        {
            return StatusCode(500);
        }
    }
    
}
