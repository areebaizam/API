using System.ComponentModel.DataAnnotations;
using System.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Domain.Shared
{
    public abstract class Response {
        public virtual ResponseStatus Status { get; set; } = new ResponseStatus();

        public virtual object? Result { get; set; } = default;
        public virtual Error[] Errors { get; set; } = [];
    }

    //public class ApiGo<TResponse>
    //{
    //    public  ApiGo(Result<TResponse> response)
    //    {
           
    //            if (response.IsSuccess)
    //            return new OkResponse<TResponse>(response);
    //        else return new ErrorResponse<TResponse>(response);
            
    //    }
    //}
    public class OkResponse<TResponse> : Response
    {
        public OkResponse(Result<TResponse> response)
        {
            Result = response.Value;
        }
    }

    public class ErrorResponse : Response 
    {
        public ErrorResponse(Error error)
        {
            Status.IsSuccess = false;
            Status.Message = error.Message;
            Status.StatusCode = error.Code;
        }

    }

    public class ErrorResponse<TResult> : Response
    {
        public ErrorResponse(ValidationResult<TResult> result)
        {
            Errors = result.Errors;
            Status.IsSuccess = false;
            Status.Message = result.Error.Message;
            Status.StatusCode = result.Error.Code;
        }
    }

    public class ResponseStatus
    {
        public ResponseStatus()
        {
            StatusCode = "Success";
            Message = "Ok";
            IsSuccess = true;
            TimeStamp = DateTime.UtcNow;//TODO Make it by default to UTC do not declare everytime
        }

        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public string StatusCode { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
