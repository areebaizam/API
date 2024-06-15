namespace Domain.Shared
{
    public class Response(bool isSuccess, object? result, Error[] errors)
    {
        public virtual ResponseStatus Status { get; set; } = new ResponseStatus(isSuccess);
        public virtual object? Next { get; } = result;
        public virtual Error[] Errors { get; set; } = errors;
    }

    public class ResponseStatus(bool isSuccess)
    {
        public bool IsSuccess { get; set; } = isSuccess;
        public string Message { get; set; } = "Ok";
        public string Code { get; set; } = "Success";
        public DateTime TimeStamp { get; set; } = DateTime.UtcNow;//TODO Make it by default to UTC do not declare everytime
    }
}
