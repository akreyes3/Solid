using SolidDemo.Loans;
using SolidDemo;

internal class PersonalLoan(int accountId, Customer customer, decimal amount, int duration) :
    Loan(accountId, customer, amount, duration)
{
}