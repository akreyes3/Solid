using SolidDemo.Accounts;
using SolidDemo.Loans;

namespace SolidDemo;

internal class Customer(int customerId, string name, IReadOnlyList<IAccount> accounts, IList<ILoan> loans)
{
    public int CustomerId { get; } = customerId;

    public string Name { get; } = name;

    public IReadOnlyList<IAccount> Accounts { get; } = accounts;
    public IList<ILoan> Loans { get; } = loans;

    public IAccount GetAccount(int accountId) => Accounts.First(a => a.AccountId == accountId);
    public void AddLoan(Loan loan)
    {
        
    }
}

