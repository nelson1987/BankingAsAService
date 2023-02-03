using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

[ApiController]
[Route("api/[controller]")]
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

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Consumes("application/json")]
    [ProducesResponseType(typeof(string), 200)]
    [ProducesResponseType(typeof(string), 400)]
    [SwaggerOperation(
        Summary = "Create a new value",
        Description = "Creates a new value",
        OperationId = "CreateValue",
        Tags = new[] { "Values" },
        RequestBody = new OpenApiRequestBody
        {
            Description = "Value to be created",
            Required = true,
            Content = new Dictionary<string, OpenApiMediaType>
            {
                { "application/json", new OpenApiMediaType
                {
                    Schema = new OpenApiSchema
                    {
                        Type = "string",
                        Example = new OpenApiString("example value"),
                        Examples = new Dictionary<string, OpenApiExample>
                        {
                            { "example1", new OpenApiExample { Value = new OpenApiString("example1 value") } },
                            { "example2", new OpenApiExample { Value = new OpenApiString("example2 value") } }
                        }
                    }
                } }
            }
        }
    )]
    public IActionResult Post([FromBody] string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return BadRequest("Value cannot be empty");
        }

        return Ok($"Value '{value}' created");
    }
}
