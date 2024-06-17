using Task01.API.DTOs.Responses;
using Task01.Application.Utilities.Exceptions;

namespace Task01.API.Middlewares
{
    public class GlobalExceptionHandlerMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<GlobalExceptionHandlerMiddleware> logger;
        public GlobalExceptionHandlerMiddleware(RequestDelegate next, ILogger<GlobalExceptionHandlerMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Task01Exception taskException) 
            {
                logger.LogInformation("Task Exception: {Message}, at {DateTime}", taskException.Message, DateTime.Now);
                await WriteBody(context, StatusCodes.Status400BadRequest, taskException.Message);
            }
            catch (ValidationException validationException)
            {
                logger.LogInformation("Validation Exception: {Message}, at {DateTime}", validationException.Message, DateTime.Now);
                await WriteBody(context, StatusCodes.Status400BadRequest, validationException.Message);
            }
            catch (Exception ex)
            {
                logger.LogError("Exception: {Message}, at {DateTime}", ex.Message, DateTime.Now);
                await WriteBody(context, StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        private static async Task WriteBody(HttpContext context, int statusCode, string message)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;
            var response = new Response
            {
                Message = message,
                Path = context.Request.Path
            };
            await context.Response.WriteAsJsonAsync(response);
        }
    }
}
