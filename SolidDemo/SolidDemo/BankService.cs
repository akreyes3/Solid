

using SolidDemo.Accounts;
using SolidDemo.Helpers;
using SolidDemo.Validations;
using System.Security.Principal;

namespace SolidDemo;

internal class BankService : IBankService
{

    private readonly ILoggingService _loggingService;
    private readonly IDictionary<AccountType, IAccountValidation> _accountValidations;
    private readonly IDictionary<LoanType, ILoanHelper> _loanHelpers;

    public BankService(ILoggingService loggingService, IEnumerable<IAccountValidation> accountValidations, IEnumerable<ILoanHelper> loanHelpers)
    {
        _loggingService = loggingService;
        _accountValidations = accountValidations.ToDictionary(x => x.AccountType, y => y);
        _loanHelpers = loanHelpers.ToDictionary(x => x.LoanType, y => y);
    }

    public void Withdraw(Customer customer, int accountId, decimal amount, string currency = "PHP")
    {
        var account = customer.GetAccount(accountId);

        if (!_accountValidations.TryGetValue(account.AccountType, out var accountValidation))
            throw new ArgumentException("Account type {account} is not Valid");

        if (accountValidation.IsValid(account, amount, currency))
        {
            account.Withdraw(amount, currency);
            _loggingService.LogMessage($"Withdrawal of {amount} successful. New balance: {account.Balance}");
        }
        else
        {
            if (account is ITimeDepositAccount timeDeposit)
                LogTimeDepositError(timeDeposit);
            else
                _loggingService.LogMessage("Withdrawal failed. Check the amount and balance.");
        }
        
    }

    public void GetLoan(Customer customer, decimal amount, int duration, LoanType loanType)
    {
        if (!_loanHelpers.TryGetValue(loanType, out var loanHelper))
            throw new ArgumentException("Account type {account} is not Valid");

        Random rnd = new Random();
        int loanId = rnd.Next(1000, 9999);
        if (loanType == LoanType.Car)
        {
            CarLoan carLoan = new CarLoan(loanId, customer, amount, duration);
            decimal loanAmount = loanHelper.CalculateLoanAmount(carLoan, amount, duration);
            LogLoanMessage("Car", loanAmount, duration);
        }
    }

    private void LogTimeDepositError(ITimeDepositAccount timeDeposit)
    {
        if (!timeDeposit.IsMatured())
            _loggingService.LogMessage("Time Deposit account did not reach maturity date");
    }

    private void LogLoanMessage(string loanType, decimal amount, int duration)
    {
        _loggingService.LogMessage($"{loanType} Loan with Duration of {duration} years to pay has been granted. total amount: {amount}");
    }
}
