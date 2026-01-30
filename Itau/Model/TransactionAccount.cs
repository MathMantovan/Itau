namespace Itau.Model
{
    public class TransactionAccount
    {
        public decimal Value { get; set; }
        public DateTime TransactionDate { get; set; }
        public TransactionAccount()
        {
            
        }
        public TransactionAccount(decimal value, DateTime transactionnDate)
        {
            Value = value;
            TransactionDate = transactionnDate;
        }
    }
}

