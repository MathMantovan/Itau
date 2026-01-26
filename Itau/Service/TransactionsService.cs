using Itau.Controllers;
using System.Drawing;
using Itau.Model;


namespace Itau.Service
{
    public class TransactionsService
    {
        public void CreateTransaction(decimal valor, DateTime transactionDate)
        {
            var transaction = new Transaction(valor, transactionDate);
            transactions.Add(transaction);
        }
    }
}
