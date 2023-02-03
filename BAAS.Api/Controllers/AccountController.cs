using Baas.Domain.Account.Create;
using Baas.Domain.Commands;
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
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator, ILogger<AccountController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet("{numero}/{idCliente}/{idEmpresa}")]
        public async Task<IActionResult> GetAccount(string numero, int idCliente)
        {
            _logger.LogDebug($"----> Page No '{numero.ToJson()}'");
            var response = await _mediator.Send(new AccountQuery()
            {
                IdCliente = idCliente,
                Numero = numero
            });
            return Ok(response);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AbriConta([FromBody] AberturaContaCommand command)
        {
            _logger.LogDebug($"----> Page No '{command.ToJson()}'");
            var response = await _mediator.Send(command);
            return Ok();
            //if (response.Errors.Any())
            //{
            //    return BadRequest(response.Errors);
            //}
            //
            //return Ok(response.Value);
        }

        /*
        [HttpDelete]
        public async Task<IActionResult> DeleteAccount([FromBody] AccountModel conta)
        {
            return Ok();
        }
        */
    }
}