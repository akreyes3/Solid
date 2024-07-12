using SolidDemo.Loans;

namespace SolidDemo.Helpers;
internal class PersonalLoanHelp : ILoanHelper
{
    public LoanType LoanType => LoanType.Personal;

    public decimal CalculateLoanAmount(ILoan loan, decimal amount, int duration)
    {
        return loan.ComputeLoan(amount, (decimal)0.03, duration);
    }
}

