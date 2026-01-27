using Itau.Controllers;
using System.Drawing;
using Itau.Model;
using Itau.Model.Entities;
using System.Security;
using System.Transactions;
using Itau.Exception;


namespace Itau.Service
{
    public class TransactionsService : ITransactionsServices
    {
        private readonly InMemoryTransactionStore transactions;
        public void CreateTransaction(decimal valor, DateTime transactionDate)
        {
            var transaction = new Model.Transaction(valor, transactionDate);
            VerificateTransaction(transaction);
            transactions.AddTransaction(transaction);
        }

        public TransactionStatistic GetStatisticsFrom60Seconds()
        {
            var AllTransactions = transactions.GetAllTransactionsInTheLast60Seconds();
            var statistics = new TransactionStatistic(AllTransactions);
            
            return statistics;
        }
        public void DeleteAllTransactions()
        {
            transactions.ClearAllTransactions();
        }

        private void VerificateTransaction(Model.Transaction transaction)
        {
            if (transaction.TransactionDate > DateTime.Now)
                throw new TransactionsException("Transaction date is invalid.");

            if(transaction.Value <= 0)
                throw new TransactionsException("Transaction value must be greater than zero.");
        }
    }
}
