using Application.Common.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Text.Json;

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

                    //context.Response.StatusCode = contextFeature.Error switch
                    //{
                    //    ValidationFailedException => StatusCodes.Status400BadRequest,
                    //    OperationCanceledException => StatusCodes.Status503ServiceUnavailable,
                    //    //NotFoundException => (int)HttpStatusCode.NotFound,
                    //    _ => StatusCodes.Status500InternalServerError
                    //};

                    //var problemDetails = new ProblemDetails
                    //{
                    //    Status = context.Response.StatusCode,
                    //    Title = contextFeature.Error.GetBaseException().Message,
                    //    Detail = contextFeature.Error.StackTrace
                    //};
                    //context.Response.WriteAsJsonAsync(new
                    //{
                    //    statusCode = context.Response.StatusCode,
                    //    message = contextFeature.Error.GetBaseException().Message
                    //});

                    //var errorResponse = new
                    //{
                    //    statusCode = context.Response.StatusCode,
                    //    message = contextFeature.Error.GetBaseException().Message
                    //};

                    //await context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
                });
            });
        }

        private static ExceptionDetails GetExceptionDetails(Exception exception)
        {
            return exception switch
            {
                ValidationFailedException validationException => new ExceptionDetails(
                    StatusCodes.Status400BadRequest,
                    "ValidationFailure",
                    "Validation error",
                    "One or more validation errors has occurred",
                    validationException.Errors),
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
