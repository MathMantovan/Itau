namespace Itau.Model
{
    public class Transaction
    {
        public decimal Value { get; set; }
        public DateTime TransactionDate { get; set; }
        public Transaction(decimal value, DateTime transactionnDate)
        {
            Value = value;
            TransactionDate = transactionnDate;
        }
    }
}

