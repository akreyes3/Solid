using SolidDemo.Accounts;
using SolidDemo.Loans;

namespace SolidDemo.Helpers;
internal interface ILoanHelper
{
    LoanType LoanType { get; }

    decimal CalculateLoanAmount(ILoan loan, decimal amount, int duration);
}
