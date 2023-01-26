using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace Baas.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [SwaggerOperation(
        Summary = "Get a value by ID",
        Description = "Retrieves a value by its ID",
        OperationId = "GetValueById",
        Tags = new[] { "Values" }
    )]
        public IActionResult Get(int id)
        {
            if (id <= 0)
            {
                return BadRequest("ID must be greater than 0");
            }

            return Ok($"Value {id}");
        }

        //[HttpPost("create")]
        //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CreateModel))]
        //[ProducesResponseType(typeof(string), 400)]
        //[SwaggerOperation(
        //    Summary = "Create a new value",
        //    Description = "Creates a new value",
        //    OperationId = "CreateValue",
        //    Tags = new[] { "Values" }
        //)]
        //public IActionResult Create([FromBody, ApiExplorerSettings(OpenApiExample Example = @"{'name':'John','age':30}")] string value)
        //{
        //    if (string.IsNullOrWhiteSpace(value))
        //    {
        //        return BadRequest("Value cannot be empty");
        //    }

        //    return Ok($"Value '{value}' created");
        //}

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
    }
}