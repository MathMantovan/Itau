namespace Itau.Exception
{
    public class TransactionsException : IOException
    {
        public TransactionsException(string message) : base(message)
        {
        }
    }
}
