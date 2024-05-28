using Domain.Shared;
using Microsoft.AspNetCore.Http.HttpResults;

namespace WebApi.Extensions
{
    public static class BaseEndpoint
    {
        public static readonly string _baseUrl = "api/";
        public static IResult ApiGo(Result result) {
            if (result.IsSuccess)
                return TypedResults.Ok(ResponseExt.Ok());
            else return ApiError(result);
        
        }
        public static IResult ApiGo<TResult>(Result<TResult> result) {
            if (result.IsSuccess)
                return TypedResults.Ok(ResponseExt.Ok(result));
            else return ApiError(result);
        }

        private static BadRequest<Response<object>> ApiError(Result result) =>
            result switch
            {
                { IsSuccess: true } => throw new InvalidOperationException(),
                _ => TypedResults.BadRequest(ResponseExt.Failure(result.Error))
            };

        private static IResult ApiError<TResult>(Result<TResult> result) =>
            result switch
            {
                { IsSuccess: true } => throw new InvalidOperationException(),
                ValidationResult<TResult> validationResult => TypedResults.BadRequest(ResponseExt.Failure(validationResult)),
                _ => TypedResults.BadRequest(ResponseExt.Failure(result.Error))
            };
    }




}
