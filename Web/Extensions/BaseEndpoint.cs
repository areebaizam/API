using Domain.Shared;
using Microsoft.AspNetCore.Http.HttpResults;

namespace WebApi.Extensions
{
    public static class BaseEndpoint
    {
        public static readonly string _baseUrl = "api/";
        public static IResult ApiGo(Result result) {
            if (result.IsSuccess)
                return ApiOk();
            else return ApiError(result);
        }
        private static Ok<OkResponse> ApiOk()
        {
            var apiResponse = new OkResponse();
            return TypedResults.Ok(apiResponse);
        }

        private static BadRequest<ErrorResponse> ApiError(Result result) =>
            result switch
            {
                { IsSuccess: true } => throw new InvalidOperationException(),
                ValidationResult validationResult => TypedResults.BadRequest(new ErrorResponse(validationResult)),
                Result errorResult => TypedResults.BadRequest(new ErrorResponse(errorResult.Error)),
                _ => TypedResults.BadRequest(new ErrorResponse(result.Error))
            };

        public static IResult ApiGo<TResult>(Result<TResult> result) {
            if (result.IsSuccess)
                return ApiOk(result);
            else return ApiError(result);
        }

        private static Ok<OkResponse<TResult>> ApiOk<TResult>(Result<TResult> result)
        {
            var apiResponse = new OkResponse<TResult>(result);
            return TypedResults.Ok((apiResponse));
        }
        
        private static IResult ApiError<TResult>(Result<TResult> result) =>
            result switch
            {
                { IsSuccess: true } => throw new InvalidOperationException(),
                ValidationResult<TResult> validationResult => TypedResults.BadRequest(new ErrorResponse<TResult>(validationResult)),
                Result<TResult> => TypedResults.BadRequest(new ErrorResponse<TResult>(result)),
                _ => TypedResults.BadRequest(result.Error)
            };
    }
            
            
            
    
}
