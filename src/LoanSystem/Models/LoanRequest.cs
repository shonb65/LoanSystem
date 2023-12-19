using System;

namespace LoanSystem.Models;
public class LoanRequest : IModel
{
    public Guid Id { get; set; }
    public int Age { get; set; }
    public decimal Amount { get; set; }
    public int Period { get; set; }
}
