using System;
using System.Collections.Generic;
using FinanceManagementSystem.Models;
using FinanceManagementSystem.Accounts;
using FinanceManagementSystem.Processors;

namespace FinanceManagementSystem.App
{
    public class FinanceApp
    {
        private List<Transaction> _transactions = new List<Transaction>();

        public void Run()
        {
            var savingsAccount = new SavingsAccount("ACC123", 1000m);

            var t1 = new Transaction(1, DateTime.Now, 150m, "Groceries");
            var t2 = new Transaction(2, DateTime.Now, 200m, "Utilities");
            var t3 = new Transaction(3, DateTime.Now, 300m, "Entertainment");

            var mobileProcessor = new MobileMoneyProcessor();
            var bankProcessor = new BankTransferProcessor();
            var cryptoProcessor = new CryptoWalletProcessor();

            mobileProcessor.Process(t1);
            bankProcessor.Process(t2);
            cryptoProcessor.Process(t3);

            savingsAccount.ApplyTransaction(t1);
            savingsAccount.ApplyTransaction(t2);
            savingsAccount.ApplyTransaction(t3);

            _transactions.AddRange(new[] { t1, t2, t3 });
        }
    }
}
