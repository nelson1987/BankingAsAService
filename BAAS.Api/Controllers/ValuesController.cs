using Baas.Domain.Commands;
using Baas.Domain.Entities;
using Baas.Domain.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace Baas.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class ValuesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ValuesController> _logger;
        // private readonly RabbitMQManager _rabbitMQ;

        public ValuesController(IMediator mediator, ILogger<ValuesController> logger)//, RabbitMQManager rabbitMQ)
        {
            this._mediator = mediator;
            _logger = logger;
            //_rabbitMQ = new RabbitMQManager();
            //_rabbitMQ.Consume("Account", OnReceive);
        }

        //private void OnReceive(string message)
        //{
        //    //processa a mensagem aqui
        //}
        /*
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MovimentacaoQueryResponse))]
        [ProducesResponseType(typeof(string), 400)]
        [SwaggerOperation(
            Summary = "Buscar Movimentações por Id",
            Description = "Retrieves a value by its ID",
            OperationId = "GetValueById",
            Tags = new[] { "Movimentacao" }
        )]
        public async Task<IActionResult> Get([FromQuery] MovimentacaoQuery query)
        {
            _logger.LogInformation("MovimentacaoQuery");
            var retorno = await _mediator.Send(query);
            return Ok(retorno);
        }
        */
        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AberturaContaCommandResponse))]
        [ProducesResponseType(typeof(string), 400)]
        [SwaggerOperation(
            Summary = "Create a new value",
            Description = "Creates a new value",
            OperationId = "CreateValue",
            Tags = new[] { "Values" }
        )]
        public async Task<IActionResult> Create([FromBody] AberturaContaCommand command)
        {
            var retorno = await _mediator.Send(command);
            return Ok(retorno);
        }
        /*
        [HttpPut("{id}")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [SwaggerOperation(
            Summary = "Update a value",
            Description = "Updates a value by its ID",
            OperationId = "UpdateValue",
            Tags = new[] { "Values" })]
        public IActionResult Put(int id, [FromBody] string value)
        {
            if (id <= 0)
            {
                return BadRequest("ID must be greater than 0");
            }

            if (string.IsNullOrWhiteSpace(value))
            {
                return BadRequest("Value cannot be empty");
            }

            return Ok($"Value {id} updated to '{value}'");
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [SwaggerOperation(
            Summary = "Delete a value",
            Description = "Deletes a value by its ID",
            OperationId = "DeleteValue",
            Tags = new[] { "Values" }
        )]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest("ID must be greater than 0");
            }

            return Ok($"Value {id} deleted");
        }
        */
    }
}