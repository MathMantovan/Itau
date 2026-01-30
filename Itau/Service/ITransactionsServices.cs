using Itau.Model;

namespace Itau.Service
{
    public interface ITransactionsServices
    {
        public void CreateTransaction(TransactionAccount transaction);
        public TransactionStatistic GetStatisticsFromAPeriodInSeconds(int period);
        public IEnumerable<TransactionAccount> GetAllTransactions();
        public void DeleteAllTransactions();
    }
}
