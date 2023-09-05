using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using System.Net.Mime;

namespace Ordenacao.Api.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception;
            var response = context.HttpContext.Response;

            response.StatusCode = StatusCodes.Status500InternalServerError;
            response.ContentType = MediaTypeNames.Application.Json;

            context.Result = new ObjectResult(GenerateResponseResult(HttpStatusCode.InternalServerError, exception.Message));
        }

        private object GenerateResponseResult(HttpStatusCode statusCode, object error)
        {
            return new
            {
                errors = new { Messages = error },
                title = "One or more errors occurred.",
                status = statusCode
            };
        }
    }
}
