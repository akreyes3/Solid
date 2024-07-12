using Microsoft.Extensions.DependencyInjection;
using SolidDemo.Accounts;
using SolidDemo.Loans;
using SolidDemo.Helpers;
using SolidDemo.Validations;

namespace SolidDemo;

internal class Program
{
    static void Main(string[] args)
    {
        var serviceCollection = new ServiceCollection();

        serviceCollection.AddScoped<ILoggingService, LoggingService>();
        serviceCollection.AddScoped<IBankService, BankService>();  

        serviceCollection.AddScoped<IAccountValidation, SavingsAccountValidation>();
        serviceCollection.AddScoped<IAccountValidation, CurrentAccountValidation>();
        serviceCollection.AddScoped<IAccountValidation, TimeDepositValidation>();
        serviceCollection.AddScoped<IAccountValidation, DollarAccountValidation>();

        serviceCollection.AddScoped<ILoanHelper, CarLoanHelper>();

        var serviceProvider = serviceCollection.BuildServiceProvider();

        var bankService = serviceProvider.GetRequiredService<IBankService>();

        var savingsAccount = new SavingsAccount(1001, 520.00m);
        var currentAccount = new CurrentAccount(1002, 500.00m, 100m);
        var dollarAccount = new DollarAccount(1004, 550.00m);
        var timeDepositAccount = new TimeDepositAccount(1003, 500m, DateTime.Today.Subtract(TimeSpan.FromDays(29)), 30);

        var customer = new Customer(1, "Juan Dela Cruz", new List<IAccount>
        {
            savingsAccount,
            currentAccount,
            timeDepositAccount,
            dollarAccount,
        },
        new List<ILoan>
        {
        }
        );


        bankService.Withdraw(customer, 1004, 8.70m, "USD");
        bankService.Withdraw(customer, 1002, 600.00m);
        bankService.Withdraw(customer, 1003, 300m);
        bankService.GetLoan(customer, 300m, 2, LoanType.Car);


        Console.ReadLine();
    }
}
