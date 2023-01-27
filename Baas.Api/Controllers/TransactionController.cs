using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
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
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [SwaggerOperation(
        Summary = "Get a value by ID",
        Description = "Retrieves a value by its ID",
        OperationId = "GetValueById",
        Tags = new[] { "Values" }
    )]
        public async Task<IActionResult> GetStatement()
        {
            var nome1 = "nelson";
            var nome2 = "Laurides";
            var verificacao = nome1 == nome2;
            //var response = await _mediator.Send(new AccountQuery() {
            //     IdCliente = idCliente,
            //     IdEmpresa = idEmpresa,
            //     Numero = numero
            //});
            //return Ok(response);
            return Ok();
        }

        [HttpPost]//("Credit")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [SwaggerOperation(
        Summary = "Create a new value",
        Description = "Creates a new value",
        OperationId = "CreateValue",
        Tags = new[] { "Values" }
    )]
        public async Task<IActionResult> Create([FromBody] GetTransactionQuery model)
        {
            var response = await _mediator.Send(model);
            return Ok(response);
            //if (response.Errors.Any())
            //{
            //    return BadRequest(response.Errors);
            //}
            //
            //return Ok(response.Value);
        }

        //[HttpPost("Debit")]
        //public async Task<IActionResult> CreateDebit([FromBody] InsertAccountCommand model)
        //{
        //    var response = await _mediator.Send(model);
        //    return Ok();
        //}
    }
}