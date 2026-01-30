namespace Itau.Model.Entities
{
    public interface ITransactionStore
    {
        public IEnumerable<TransactionAccount> GetAllTransactionsInThePeriodInSeconds(int period);
        public IEnumerable<TransactionAccount> GetAllTransactions();
        public void AddTransaction(TransactionAccount transaction);
        public void ClearAllTransactions();
    }
}
