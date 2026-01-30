using Microsoft.AspNetCore.Mvc;
using Itau.Service;
using Itau.Exception;
using System.Transactions;
using Itau.Model;

namespace Itau.Controllers
{
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionsServices _transactionsService;
        public TransactionController(ITransactionsServices transactionsService)
        {
            _transactionsService = transactionsService;
        }
        [HttpPost("/v1/transaction")]
        public IActionResult CreateTransaction([FromBody] TransactionAccount transaction)
        {
            if (transaction == null)
                return BadRequest();
            try
            {
                _transactionsService.CreateTransaction(transaction);
                return Created();
            }
            catch (TransactionsException ex)
            {
                return UnprocessableEntity(ex.Message);
            }
        }

        [HttpGet("/v1/alltransaction")]
        public IActionResult GetAllTransactions()
        {
            var transactions = _transactionsService.GetAllTransactions();
            return Ok(transactions);
        }

        [HttpGet("/v1/statistic/{period:int}")]
        public IActionResult GetStatisticSinceAPeriod([FromRoute] int period)
        {
            var statistics = _transactionsService.GetStatisticsFromAPeriodInSeconds(period);
            return Ok(statistics);
        }

        [HttpDelete("/v1/transaction")]
        public IActionResult DeleteAllTransactions()
        {
            _transactionsService.DeleteAllTransactions();
            return Ok();
        }
    }
}
