namespace Application.Common.Exceptions
{
    public class ValidationFailedException : Exception
    {
        public ValidationFailedException(IReadOnlyCollection<ValidationError> errors)
            : base("Invalid Request")
        {
            Errors = errors;
        }

        public IReadOnlyCollection<ValidationError> Errors { get; }
    }

    public record ValidationError(string PropertyName, string ErrorMessage);
}
