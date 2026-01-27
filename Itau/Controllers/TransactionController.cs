using Microsoft.AspNetCore.Mvc;
using Itau.Service;
using Itau.Exception;

namespace Itau.Controllers
{
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly TransactionsService _transactionsService;
        [HttpPost("/v1/transaction")]
        public IActionResult CreateTransaction([FromBody] decimal valor, [FromBody] DateTime transactionDate)
        {
            if (valor == null || transactionDate == null)
                return BadRequest();
            try
            {
                _transactionsService.CreateTransaction(valor, transactionDate);
                return Created();
            }
            catch (TransactionsException ex)
            {
                return UnprocessableEntity(ex.Message);
            }
        }
        [HttpGet("/v1/statistic")]
        public IActionResult GetStatisticSinceAPeriod()
        {
            var statistics = _transactionsService.GetStatisticsFrom60Seconds();
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
