using Baas.Domain.Account.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Baas.Api.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [Consumes("application/json")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ILogger<TransactionController> _logger;
        private readonly IMediator _mediator;

        public TransactionController(IMediator mediator, ILogger<TransactionController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        //[InactivedEndpoint]
        public async Task<IActionResult> GetStatement()
        {
            //var response = await _mediator.Send(new AccountQuery() { 
            //     IdCliente = idCliente,
            //     IdEmpresa = idEmpresa,
            //     Numero = numero
            //});
            //return Ok(response);
        }


        [HttpPost("Credit")]
        public async Task<IActionResult> CreateCredit([FromBody] CreateAccountCommand model)
        {
            var response = await _mediator.Send(model);
            return Ok();
            //if (response.Errors.Any())
            //{
            //    return BadRequest(response.Errors);
            //}
            //
            //return Ok(response.Value);
        }

        [HttpPost("Debit")]
        public async Task<IActionResult> CreateDebit([FromBody] CreateAccountCommand model)
        {
            var response = await _mediator.Send(model);
            return Ok();
        }
    }
}