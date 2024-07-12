namespace SolidDemo;

internal interface IBankService
{
    void Withdraw(Customer customer, int accountId, decimal amount, string currency = "PHP");
    void GetLoan(Customer customer, decimal amount, int duration, LoanType loanType);
}