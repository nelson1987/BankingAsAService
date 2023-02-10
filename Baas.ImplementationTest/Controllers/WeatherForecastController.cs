using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Baas.ImplementationTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Product 1", Price = 10 },
            new Product { Id = 2, Name = "Product 2", Price = 20 },
            new Product { Id = 3, Name = "Product 3", Price = 30 }
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetProducts")]
        public IActionResult Products()
        {
            throw new NotImplementedException();
            return Ok(products);
        }

        [HttpPost(Name = "PostProducts")]
        public IActionResult PostProducts([FromBody] ProductModel model)
        {
            throw new NotImplementedException();
            return Ok(products);
        }
    }
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class YourModelValidator : AbstractValidator<ProductModel>
    {
        public YourModelValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Your Property cannot be empty.");
            RuleFor(x => x.Id).NotEmpty().WithMessage("Your Property cannot be empty.");

        }
    }
    public class ServiceException : Exception
    {
        public ServiceException(string message) : base(message)
        {
        }
    }
    public class RepositoryException : Exception
    {
        public RepositoryException(string message) : base(message)
        {
        }
    }
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;

            if (exception is ServiceException) code = HttpStatusCode.PreconditionFailed;
            if (exception is RepositoryException) code = HttpStatusCode.BadGateway;

            var result = JsonConvert.SerializeObject(new { error = exception.Message });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
    }
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(context.ModelState);
            }
        }
    }
}
