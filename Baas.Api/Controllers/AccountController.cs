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
    public partial class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{numero}/{idCliente}/{idEmpresa}")]
        //[InactivedEndpoint]
        public async Task<IActionResult> GetAccount(string numero, string idCliente, string idEmpresa)
        {
            var response = await _mediator.Send(new AccountQuery() { 
                 IdCliente = idCliente,
                 IdEmpresa = idEmpresa,
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

        /*
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