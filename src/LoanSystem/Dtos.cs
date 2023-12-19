namespace LoanSystem.Dtos;

public record LoanRequestDto(Guid ClientId, decimal Amount, int Period);
public record CreateUserDto(int Age);