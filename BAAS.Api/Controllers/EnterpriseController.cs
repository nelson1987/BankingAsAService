using Baas.Domain.Account.Create;
using Baas.Domain.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Baas.Api.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [Consumes("application/json")]
    [ApiController]
    public class EnterpriseController : ControllerBase
    {
        private readonly ILogger<EnterpriseController> _logger;
        private readonly IMediator _mediator;

        public EnterpriseController(IMediator mediator, ILogger<EnterpriseController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        /// <summary>
        /// Criar Empresa
        /// </summary>
        /// <param name="empresa"></param>
        /// <returns></returns>
        [HttpGet]/*("/Enterprise/{id:int}")]*/
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetEnterprise()/*[FromRoute] int id)*/
        {
            _logger.LogDebug($"----> Page No GetEnterprise");
            var result = await _mediator.Send(new AccountQuery());
            //return BadRequest(ErroPadrao.Teste);
            //throw new HttpResponseException(400,"teste");
            return Ok();
        }

        /// <summary>
        /// Criar Empresa
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateEnterprise([FromBody] InsertAccountCommand command)
        {
            _logger.LogDebug($"----> Page No '{command.ToJson()}'");
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetEnterprise), new { id = command.Id }, command);
        }

        [HttpDelete]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteEnterprise([FromBody] DeleteAccountCommand command)
        {
            _logger.LogDebug($"----> Page No '{command.ToJson()}'");
            return Ok();
        }
    }
}