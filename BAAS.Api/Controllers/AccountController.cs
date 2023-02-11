using Baas.Domain.Account.Create;
using Baas.Domain.Commands;
using BAAS.Api.Security;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Baas.Api.Controllers
{
    /*
    Iniciar Abertura de Conta
    Listar Contas
    */
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
/*
        [HttpGet("{IdCliente}/{Tipo}/{Numero}")]
        public async Task<IActionResult> GetAccount([FromRoute] AccountQuery query)
        {
            _logger.LogDebug($"----> Page No '{query.ToJson()}'");
            var response = await _mediator.Send(query);
            #region
            var jwtTokenHandler = new JwtTokenHandler("SECRET_KEY");

            // Gerando token
            var token = jwtTokenHandler.CreateToken("partner_name", DateTime.Now.AddMinutes(30));

            // Validando token
            JwtToken jwtToken;
            if (jwtTokenHandler.ValidateToken(token.Token, out jwtToken))
            {
                // Token válido
                // Faça alguma coisa com jwtToken.Partner
            }
            else
            {
                // Token inválido
            }
            #endregion
            return Ok(response);
        }
*/
        [HttpPost]
        public async Task<IActionResult> AbriConta([FromBody] AberturaContaCommand command)
        {
            _logger.LogDebug($"----> Page No '{command.ToJson()}'");
            var response = await _mediator.Send(command);
            return Ok();
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