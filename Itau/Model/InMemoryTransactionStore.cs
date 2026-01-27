using Itau.Model.Entities;

namespace Itau.Model
{
    public class InMemoryTransactionStore : ITransactionStore
    {
        private List<Transaction> StoreType { get; set; }

        public InMemoryTransactionStore()
        {
            StoreType = new List<Transaction>();
        }
        public List<Transaction> GetAllTransactionsInTheLast60Seconds()
        {
            return (List<Transaction>)StoreType.Where(x => x.TransactionDate >= DateTime.Now.AddSeconds(-60));
        }
        public void AddTransaction(Transaction transaction)
        {
            StoreType.Add(transaction);
        }
        public void ClearAllTransactions()
        {
            StoreType.Clear();
        }
    }
}
