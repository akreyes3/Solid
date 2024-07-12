using SolidDemo.Loans;

namespace SolidDemo.Helpers;
internal class CarLoanHelper: ILoanHelper
{
    public LoanType LoanType => LoanType.Car;

    public decimal CalculateLoanAmount(ILoan loan, decimal amount, int duration)
    {
        return loan.ComputeLoan(amount, (decimal)0.05, duration);
    }
}

