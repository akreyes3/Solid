using System.ComponentModel.DataAnnotations;

namespace SolidDemo.Accounts;

internal class DollarAccount(int accountId, decimal balance) :
    Account(accountId, balance), IDollarAccount
{
    public AccountType AccountType => AccountType.DollarAccount;
}
