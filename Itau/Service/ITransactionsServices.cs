using Itau.Model;

namespace Itau.Service
{
    public interface ITransactionsServices
    {
        public void CreateTransaction(decimal valor, DateTime transactionDate);
        public TransactionStatistic GetStatisticsFrom60Seconds();
        public void DeleteAllTransactions();
    }
}
