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
    public class ClientController : ControllerBase
    {
        private readonly ILogger<ClientController> _logger;
        private readonly IMediator _mediator;

        public ClientController(IMediator mediator, ILogger<ClientController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }
/*
        [HttpGet("{numero}/{idCliente}/{idEmpresa}")]
        public async Task<IActionResult> Get(string numero, int idCliente)
        {
            _logger.LogDebug($"----> Page No '{numero.ToJson()}'");
            var response = await _mediator.Send(new AccountQuery()
            {
                IdCliente = idCliente,
                Numero = numero
            });
            return Ok(response);
        }

        //[HttpPost]
        //public async Task<IActionResult> CreateAccount([FromBody] CreateAccountCommand model)
        //{
        //    var response = await _mediator.Send(model);
        //    return Ok();
        //    //if (response.Errors.Any())
        //    //{
        //    //    return BadRequest(response.Errors);
        //    //}
        //    //
        //    //return Ok(response.Value);
        //}

        [HttpDelete]
        public async Task<IActionResult> DeleteAccount([FromBody] AccountModel conta)
        {
            return Ok();
        }
        */
    }
}