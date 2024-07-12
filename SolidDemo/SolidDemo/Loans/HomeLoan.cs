using SolidDemo.Loans;
using SolidDemo;

internal class HomeLoan(int accountId, Customer customer, decimal amount, int duration) :
    Loan(accountId, customer, amount, duration)
{
}