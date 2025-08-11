using System;
using FinanceManagementSystem.Models;
using FinanceManagementSystem.Interfaces;

namespace FinanceManagementSystem.Processors
{
    public class CryptoWalletProcessor : ITransactionProcessor
    {
        public void Process(Transaction transaction)
        {
            Console.WriteLine($"[Crypto Wallet] Processed  ₵{transaction.Amount} for {transaction.Category}");
        }
    }
}
