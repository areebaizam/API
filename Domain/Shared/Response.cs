using System.ComponentModel.DataAnnotations;
using static System.Net.Mime.MediaTypeNames;

namespace Domain.Shared
{
    public abstract class Response(bool isSuccess)
    {
        public virtual ResponseStatus Status { get; set; } = new ResponseStatus(isSuccess);
        public virtual Error[] Errors { get; set; } = [];
    }

    public abstract class Response<TResponse>(bool isSuccess, TResponse? result): Response(isSuccess) {
        public TResponse Next { get;} = result;
    }

    public class OkResponse : Response
    {
        public OkResponse() : base(true)
        {
        }
    }
    public class OkResponse<TResponse>(Result<TResponse> response) : Response<TResponse>(true, response.Value)
    {
    }

    public class ErrorResponse<TResponse> : Response<TResponse>
    {
        public ErrorResponse(ValidationResult<TResponse> result) : base(false, default)
        {
            Errors = result.Errors;
            Status.Message = result.Error.Message;
            Status.StatusCode = result.Error.Code;
        } 
        public ErrorResponse(Result<TResponse> result) : base(false, default)
        {
            Status.IsSuccess = false;
            Status.Message = result.Error.Message;
            Status.StatusCode = result.Error.Code;
        }        
    }
    public class ErrorResponse: Response
    {
        public ErrorResponse(ValidationResult result) : base(false)
        {
            Errors = result.Errors;
            Status.Message = result.Error.Message;
            Status.StatusCode = result.Error.Code;
        }
        public ErrorResponse(Error error) : base(false)
        {
            Status.Message = error.Message;
            Status.StatusCode = error.Code;
        }
        
    }

    public class ResponseStatus(bool isSuccess)
    {
        public bool IsSuccess { get; set; } = isSuccess;
        public string Message { get; set; } = "Ok";
        public string StatusCode { get; set; } = "Success";
        public DateTime TimeStamp { get; set; } = DateTime.UtcNow;//TODO Make it by default to UTC do not declare everytime
    }
}
