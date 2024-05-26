using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
//TODO Remove MVC and make standard response
namespace WebApi.Extensions
{
    public static class ExceptionHandler
    {
        public static void UseAppExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature == null) return;

                    context.Response.Headers.Append("Access-Control-Allow-Origin", "*");
                    context.Response.ContentType = "application/json";
                    //_logger.LogError(exception, "Exception occurred: {Message}", exception.Message);
                    var exceptionDetails = GetExceptionDetails(contextFeature.Error);
                    //TODO return Exception in standard format
                    var problemDetails = new ProblemDetails
                    {
                        Status = exceptionDetails.Status,
                        Type = exceptionDetails.Type,
                        Title = exceptionDetails.Title,
                        Detail = exceptionDetails.Detail,
                    };

                    if (exceptionDetails.Errors is not null)
                    {
                        problemDetails.Extensions["errors"] = exceptionDetails.Errors;
                    }

                    context.Response.StatusCode = exceptionDetails.Status;

                    await context.Response.WriteAsJsonAsync(problemDetails);
                });
            });
        }

        private static ExceptionDetails GetExceptionDetails(Exception exception)
        {
            return exception switch
            {
                OperationCanceledException => new ExceptionDetails(
                    StatusCodes.Status503ServiceUnavailable,
                    "ServiceUnavailable",
                    "Service Unavailable",
                    "An unexpected error has occurred due to service unavailabilty or cancelleation of request",
                    null
                    ),
                _ => new ExceptionDetails(
                    StatusCodes.Status500InternalServerError,
                    "ServerError",
                    "Server error",
                    "An unexpected error has occurred. Please try again after some time",
                    null)
            };
        }
    }

    internal record ExceptionDetails(int Status, string Type, string Title, string Detail, IEnumerable<object>? Errors);
}
