using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Domain.Shared
{
    public class ResponseExt
    {
        public static Response Ok(object? result)
        {
            return new Response(true, result, []);
        }

        public static Response Failure<TResult>(ValidationResult<TResult> result)
        {
            var errorResponse = new Response(false, default, result.Errors);
            errorResponse.Status.Message = result.Error.Message;
            errorResponse.Status.Code = result.Error.Code;

            return errorResponse;
        }
        public static Response Failure(Error error)
        {
            var errorResponse =  new Response(false, default, []);
            errorResponse.Status.Message = error.Message;
            errorResponse.Status.Code = error.Code;

            return errorResponse;
        }
    }
}