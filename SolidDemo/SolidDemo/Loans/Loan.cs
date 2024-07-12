using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidDemo.Loans;
internal abstract class Loan(int accountId, Customer customer, decimal amount, int duration) : ILoan
{
    public int LoanId { get; } = accountId;

    public Customer Customer { get; } = customer;

    public decimal Amount { get; set; } = amount;
    public int Duration { get; set; } = duration;

    public decimal ComputeLoan(decimal amount, decimal interestRate, int duration)
    {
        decimal interest = (decimal)Math.Pow((double)1 + (double)interestRate, duration);

        return amount * interest;
    }
}
