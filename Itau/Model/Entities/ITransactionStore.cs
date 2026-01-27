namespace Itau.Model.Entities
{
    public interface ITransactionStore
    {
        public List<Transaction> GetAllTransactionsInTheLast60Seconds();
        public void AddTransaction(Transaction transaction);
        public void ClearAllTransactions();
    }
}
