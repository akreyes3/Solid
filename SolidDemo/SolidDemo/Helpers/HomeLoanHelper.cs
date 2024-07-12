using SolidDemo.Loans;

namespace SolidDemo.Helpers;
internal class HomeLoanHelper : ILoanHelper
{
    public LoanType LoanType => LoanType.Home;

    public decimal CalculateLoanAmount(ILoan loan, decimal amount, int duration)
    {
        return loan.ComputeLoan(amount, (decimal)0.02, duration);
    }
}

