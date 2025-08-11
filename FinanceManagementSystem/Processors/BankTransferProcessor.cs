using System;
using FinanceManagementSystem.Models;
using FinanceManagementSystem.Interfaces;

namespace FinanceManagementSystem.Processors
{
    public class BankTransferProcessor : ITransactionProcessor
    {
        public void Process(Transaction transaction)
        {
            Console.WriteLine($"[Bank Transfer] Processed  ₵{transaction.Amount} for {transaction.Category}");
        }
    }
}
