namespace SolidDemo.Loans;

internal interface ILoan
{
    int LoanId { get; }
    decimal Amount { get; set; }
    Customer Customer { get; }
    int Duration { get; set; }

    decimal ComputeLoan(decimal amount, decimal interestRate, int duration);
}