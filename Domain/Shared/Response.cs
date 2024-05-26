namespace Domain.Shared
{
    public abstract class Response(bool isSuccess) {
        public virtual ResponseStatus Status { get; set; } = new ResponseStatus(isSuccess);
        public virtual object Result { get; set; } = new object();
        public virtual Error[] Errors { get; set; } = [];
    }

        public class OkResponse : Response
    {
        public OkResponse() : base(true)
        {
        }
    }
    public class OkResponse<TResponse> : Response
    {
        public OkResponse(Result<TResponse> response) : base(true) => Result = response.Value!;
    }

    public class ErrorResponse : Response 
    {
        public ErrorResponse(Error error) : base(false)
        {
            Status.Message = error.Message;
            Status.StatusCode = error.Code;
        }

    }

    public class ErrorResponse<TResult> : Response
    {
        public ErrorResponse(ValidationResult<TResult> result) : base(false)
        {
            Errors = result.Errors;
            Status.IsSuccess = false;
            Status.Message = result.Error.Message;
            Status.StatusCode = result.Error.Code;
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
