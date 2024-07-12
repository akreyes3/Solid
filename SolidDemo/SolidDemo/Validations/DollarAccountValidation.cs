using SolidDemo.Accounts;
using System.Security.Principal;

namespace SolidDemo.Validations;

internal class DollarAccountValidation : IAccountValidation
{
    public AccountType AccountType => AccountType.DollarAccount;

    public decimal CalculateAmount(decimal amount, string currency)
    {
        if (currency == "PHP") return amount * (decimal)(1.02); 
        else if (currency == "USD") return amount * (decimal)(1.02) * 57;
        else throw new ArgumentException($"currency type is unavailable");
    }

    public bool IsValid(IAccount account, decimal amount, string currency = "PHP")
    {
        if (account is DollarAccount dollarAccount)
        {
            if (amount <= 0 || CalculateAmount(amount, currency) > dollarAccount.Balance)
                return false;

            return true;
        }

        throw new ArgumentException($"Account type {account} is not Dollar Account");
    }
}
