using Hospital.Core.Extentions;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;

namespace Hospital.Core.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var response = context.Response;
            response.ContentType = "application/json";
            HttpStatusCode status;
            var stackTrace = string.Empty;

            switch (exception)
            {
                case NotFoundException e:
                    status = HttpStatusCode.NotFound;
                    break;
                default:
                    status = HttpStatusCode.InternalServerError;
                    stackTrace = exception.StackTrace;
                    break;
            }

            var result = JsonSerializer.Serialize(new
            {
                error = exception?.Message,
                stackTrace
            });

            response.StatusCode = (int)status;
            return response.WriteAsync(result);
        }
    }
}
