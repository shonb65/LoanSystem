
namespace LoanSystem.Models;
public class User : IModel
{
    public Guid Id { get; set; }
    public int Age { get; set; }
}