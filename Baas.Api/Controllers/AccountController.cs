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
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        ///// <summary>
        ///// Criar Empresa
        ///// </summary>
        ///// <param name="empresa"></param>
        ///// <returns></returns>
        //[HttpGet]/*("/Enterprise/{id:int}")]*/
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<IActionResult> GetEnterprise()/*[FromRoute] int id)*/
        //{
        //    var result = await _mediator.Send(new )
        //    //return BadRequest(ErroPadrao.Teste);
        //    //throw new HttpResponseException(400,"teste");
        //    return Ok();
        //}

        //[HttpGet]
        //[InactivedEndpoint]
        //public async Task<IActionResult> GetAccount()
        //{
        //    return Ok();
        //}
        /*
        /// <summary>
        /// Criar Empresa
        /// </summary>
        /// <param name="empresa"></param>
        /// <returns></returns>
        [HttpPost("/Enterprise")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateEnterprise([FromBody] EnterpriseModel empresa)
        {
            return CreatedAtAction(nameof(GetEnterprise), new { id = empresa.Id }, empresa);
        }
        */

        [HttpPost]
        public async Task<IActionResult> CreateAccount([FromBody] CreateAccountCommand model)
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

        /*
        [HttpDelete("/Enterprise")]
        public async Task<IActionResult> DeleteEnterprise([FromBody] EnterpriseModel empresa)
        {
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAccount([FromBody] AccountModel conta)
        {
            return Ok();
        }
        */
    }

    public class EnterpriseModel
    {
        public int Id { get; set; }
    }
}