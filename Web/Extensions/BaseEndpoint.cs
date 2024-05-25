using Azure.Core;
using Azure;
using Domain.Shared;
using System.Net;
using Application.Features.UserFeatures;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;

namespace WebApi.Extensions
{
    public static class BaseEndpoint
    {
        //public static IResult ApiGo<TResult>(Result<TResult> result) =>

        //    result switch
        //    {

        //        ValidationResult<TResult> validationResult => TypedResults.BadRequest(validationResult.Errors),
        //        _ => result.IsSuccess
        //               ? TypedResults.Ok(result.Value)
        //               : TypedResults.BadRequest(result.Error)
        //    };


        //return result.IsSuccess
        //    ? TypedResults.Ok(result.Value)
        //    : TypedResults.BadRequest(result.Error);

        public static IResult ApiGo<TResult>(Result<TResult> result) {
            if (result.IsSuccess)
                return ApiOk(result);
            else return ApiError(result);
                //ypedResults.BadRequest(new ErrorResponse<AddUserResponse>(response))
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
                Result<TResult> errorResult => TypedResults.BadRequest(new ErrorResponse(errorResult.Error)),
                _ => TypedResults.BadRequest(result.Error)
            };
        //{
        //    var apiResponse = new OkResponse<TResult>(result);
        //    return TypedResults.Ok((apiResponse));
        //}


    }
            
            
            
    
}
