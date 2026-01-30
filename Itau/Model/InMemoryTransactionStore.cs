using Itau.Model.Entities;

namespace Itau.Model
{
    public class InMemoryTransactionStore : ITransactionStore
    {
        private List<TransactionAccount> StoreType { get; set; }

        public InMemoryTransactionStore()
        {
            StoreType = new List<TransactionAccount>();
        }
        public IEnumerable<TransactionAccount> GetAllTransactionsInThePeriodInSeconds(int period)
        {
            return StoreType.Where(x => x.TransactionDate >= DateTime.Now.AddSeconds(- period)).ToList();
        }
        public void AddTransaction(TransactionAccount transaction)
        {
            StoreType.Add(transaction);
        }
        public void ClearAllTransactions()
        {
            StoreType.Clear();
        }

        public IEnumerable<TransactionAccount> GetAllTransactions()
        {
            return StoreType;
        }
    }
}
