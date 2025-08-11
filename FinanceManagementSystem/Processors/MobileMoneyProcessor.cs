using System;
using FinanceManagementSystem.Models;
using FinanceManagementSystem.Interfaces;

namespace FinanceManagementSystem.Processors
{
    public class MobileMoneyProcessor : ITransactionProcessor
    {
        public void Process(Transaction transaction)
        {
            Console.WriteLine($"[Mobile Money] Processed  ₵{transaction.Amount} for {transaction.Category}");
        }
    }
}
