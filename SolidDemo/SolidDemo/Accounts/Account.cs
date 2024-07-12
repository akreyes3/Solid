namespace SolidDemo.Accounts;

internal abstract class Account(int accountId, decimal balance)
{
    public int AccountId { get; } = accountId;

    public decimal Balance { get; set; } = balance;

    public void Deposit(decimal amount)
    {
        Balance += amount;
    }

    public void Withdraw(decimal amount, string currency = "PHP")
    {

        if (this is DollarAccount dollarAccount)
        {
            if (currency == "PHP") Balance -= (amount) * (decimal)(1.02);
            else Balance -= (amount) * (decimal)(1.02) * 57;
        }

        else
        {
            Balance -= amount;
        }

    }

}
