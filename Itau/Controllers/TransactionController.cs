using Microsoft.AspNetCore.Mvc;
using Itau.Model;

namespace Itau.Controllers
{
    [ApiController]
    public class TransactionController : ControllerBase
    {
        [HttpPost("/v1/transaction")]
        public IActionResult CreateTransaction([FromBody] decimal valor, [FromBody] DateTime transactionDate)
        {
            var transaction = new Transaction(valor, transactionDate);
            transactions.Add(transaction);

            return Ok();
        }

        [HttpGet("/v1/statistic")]
        public IActionResult GetStatisticSinceAPeriod()
        {
            return View();
        }

        [HttpDelete("/v1/transaction")]
        public IActionResult DeleteAllTransactions()
        {
            return View();
        }
    }
}
