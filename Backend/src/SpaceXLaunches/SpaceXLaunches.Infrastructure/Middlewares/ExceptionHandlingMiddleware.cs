using Microsoft.Extensions.Logging;
using System.Net;
using Microsoft.AspNetCore.Http;
using SpaceXLaunches.Application.Common.Exceptions;

namespace SpaceXLaunches.Infrastructure.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        public RequestDelegate requestDelegate;
        private readonly ILogger<ExceptionHandlingMiddleware> logger;
        public ExceptionHandlingMiddleware(RequestDelegate requestDelegate, ILogger<ExceptionHandlingMiddleware> logger)
        {
            this.requestDelegate = requestDelegate;
            this.logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await requestDelegate(context);
            }
            catch (NotFoundException ex)
            {
                await HandleNotFoundException(context, ex);
            }
            catch (Exception ex)
            {
                await HandleException(context, ex);
            }
        }

        private Task HandleException(HttpContext context, Exception ex)
        {
            //TODO: We can customize this too.
            logger.LogError(ex.ToString());
            var errorMessageObject = new { Message = ex.Message, Code = "App Error" };
            var errorMessage = System.Text.Json.JsonSerializer.Serialize(errorMessageObject);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return context.Response.WriteAsync(errorMessage);
        }
        private Task HandleNotFoundException(HttpContext context, Exception ex)
        {
            var errorMessageObject = new { Message = "The entity you are looking for can't be found!", Code = "404 Not Found" };
            var errorMessage = System.Text.Json.JsonSerializer.Serialize(errorMessageObject);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.NotFound;
            return context.Response.WriteAsync(errorMessage);
        }

    }
}