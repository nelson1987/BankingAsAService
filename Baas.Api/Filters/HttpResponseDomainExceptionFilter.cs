using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace Baas.Api.Filters
{
    public class HttpResponseException : Exception
    {
        public HttpResponseException(int statusCode, object? value = null) =>
            (StatusCode, Value) = (statusCode, value);
        public int StatusCode { get; }
        public object? Value { get; }
    }
    public class HttpResponseExceptionFilter : IActionFilter, IOrderedFilter
    {
        public int Order => int.MaxValue - 10;
        public void OnActionExecuting(ActionExecutingContext context)
        {
            ////var param = context.ActionArguments.SingleOrDefault();// p => p.Value is IEntity);
            ////if (param.Value == null)
            ////{
            ////    context.Result = new BadRequestObjectResult("Object is null");
            ////    return;
            ////}

            ////if (!context.ModelState.IsValid)
            ////{
            ////    context.Result = new UnprocessableEntityObjectResult(context.ModelState);
            ////}
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is HttpResponseException httpResponseException)
            {
                context.Result = new ObjectResult(httpResponseException.Value)
                {
                    StatusCode = httpResponseException.StatusCode
                };

                context.ExceptionHandled = true;
            }
        }
    }
    public class HttpResponseDomainExceptionFilter : IActionFilter, IOrderedFilter
    {
        public int Order => int.MaxValue - 10;
        public void OnActionExecuting(ActionExecutingContext context)
        {
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Result is HttpResponseException httpResponseException)
            {
                context.Result = new ObjectResult(httpResponseException.Value)
                {
                    StatusCode = httpResponseException.StatusCode
                };

                context.ExceptionHandled = true;
            }
        }
    }
    public class InactivedEndpointAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            context.Result = new BadRequestObjectResult("Endpoint Inativo");
        }
        public void OnActionExecuted(ActionExecutedContext context)
        { }
    }

}
