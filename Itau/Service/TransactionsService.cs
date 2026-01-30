using Itau.Model;
using Itau.Model.Entities;
using Itau.Exception;


namespace Itau.Service
{
    public class TransactionsService : ITransactionsServices
    {
        private readonly ITransactionStore transactions;
        public TransactionsService(ITransactionStore transactionStore)
        {
            transactions = transactionStore;
        }
        public void CreateTransaction(TransactionAccount transaction)
        {
            VerificateTransaction(transaction);
            transactions.AddTransaction(transaction);
        }

        public TransactionStatistic GetStatisticsFromAPeriodInSeconds(int period)
        {
            var transactionsInThePeriod = transactions.GetAllTransactionsInThePeriodInSeconds(period);
            var statisticsFromThePeriod = new TransactionStatistic(transactionsInThePeriod);
            
            return statisticsFromThePeriod;
        }
        public IEnumerable<TransactionAccount> GetAllTransactions()
        {
            return transactions.GetAllTransactions();
        }
        public void DeleteAllTransactions()
        {
            transactions.ClearAllTransactions();
        }

        private void VerificateTransaction(TransactionAccount transaction)
        {
            if (transaction.TransactionDate > DateTime.Now)
                throw new TransactionsException("Transaction date is invalid.");

            if(transaction.Value <= 0)
                throw new TransactionsException("Transaction value must be greater than zero.");
        }
    }
}
