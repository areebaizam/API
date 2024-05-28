using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Domain.Shared
{
    public class ResponseExt
    {
        public static Response<TResult> Ok<TResult>(Result<TResult> result)
        {
            return new Response<TResult>(true, result.Value, []);
        }

        public static Response<object> Ok()
        {
            return new Response<object>(true, default, []);
        }

        public static Response<TResult> Failure<TResult>(ValidationResult<TResult> result)
        {
            var errorResponse = new Response<TResult>(false, default, result.Errors);
            errorResponse.Status.Message = result.Error.Message;
            errorResponse.Status.Code = result.Error.Code;

            return errorResponse;
        }
        public static Response<object> Failure(Error error)
        {
            var errorResponse =  new Response<object>(false, default, []);
            errorResponse.Status.Message = error.Message;
            errorResponse.Status.Code = error.Code;

            return errorResponse;
        }
    }
}