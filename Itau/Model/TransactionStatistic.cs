using System.Security.Principal;

namespace Itau.Model
{
    public class TransactionStatistic
    {
        public int Count { get; set; }
        public decimal Sum { get; set; }
        public decimal Average { get; set; }
        public decimal Max { get; set; }
        public decimal Min { get; set; }
        public TransactionStatistic(IEnumerable<TransactionAccount> AllTransactions)
        {
            Count = CountAmountOfTransactions(AllTransactions);
            Sum = SumTransactionsValues(AllTransactions);
            Average = AverageTransactionsValues(AllTransactions);
            Max = MaxTransactionValue(AllTransactions);
            Min = MinTransactionValue(AllTransactions);
        }
        public int CountAmountOfTransactions(IEnumerable<TransactionAccount> AllTransactions)
        {
            var Count = AllTransactions.Count();
            return Count;
        }
        public decimal SumTransactionsValues(IEnumerable<TransactionAccount> AllTransactions)
        {
            var Sum = AllTransactions.Sum(x => x.Value);
            return Sum;
        }
        public decimal AverageTransactionsValues(IEnumerable<TransactionAccount> AllTransactions)
        {
            var Average = AllTransactions.Average(x => x.Value);
            return Average;
        }
        public decimal MaxTransactionValue(IEnumerable<TransactionAccount> AllTransactions)
        {
            var Max = AllTransactions.Max(x => x.Value);
            return Max;
        }
        public decimal MinTransactionValue(IEnumerable<TransactionAccount> AllTransactions)
        {
            var Min = AllTransactions.Min(x => x.Value);
            return Min;
        }
    }
}
