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
        public TransactionStatistic(List<Transaction> AllTransactions)
        {
            Count = CountAmountOfTransactions(AllTransactions);
            Sum = SumTransactionsValues(AllTransactions);   
            Average = AverageTransactionsValues(AllTransactions);
            Max = MaxTransactionValue(AllTransactions);
            Min = MinTransactionValue(AllTransactions);
        }
        public int CountAmountOfTransactions(List<Transaction> AllTransactions)
        {
            var lastMinute = DateTime.Now.AddMinutes(-1);
            var Count = AllTransactions.Count(x => x.TransactionDate >= DateTime.Now.AddSeconds(-60));
            return Count;
        }
        public decimal SumTransactionsValues(List<Transaction> AllTransactions)
        {
            var Sum = AllTransactions.Where(x => x.TransactionDate >= DateTime.Now.AddSeconds(-60)).Sum(x => x.Value);
            return Sum;
        }
        public decimal AverageTransactionsValues(List<Transaction> AllTransactions)
        {
            var Average = AllTransactions.Where(x => x.TransactionDate >= DateTime.Now.AddSeconds(-60)).Average(x => x.Value);
            return Average;
        }
        public decimal MaxTransactionValue(List<Transaction> AllTransactions)
        {
            var Max = AllTransactions.Where(x => x.TransactionDate >= DateTime.Now.AddSeconds(-60)).Max(x => x.Value);
            return Max;
        }
        public decimal MinTransactionValue(List<Transaction> AllTransactions)
        {
            var Min = AllTransactions.Where(x => x.TransactionDate >= DateTime.Now.AddSeconds(-60)).Min(x => x.Value);
            return Min;
        }
    }
}
