namespace Domain.Shared
{
    public class ValidationResult(Error[] errors) : Result(false, Error.Validation())
    {
        public Error[] Errors { get; } = errors;

        public static ValidationResult WithErrors(Error[] errors) => new(errors);
    }
    public sealed class ValidationResult<TValue> : Result<TValue>
    {
        private ValidationResult(Error[] errors) : base(default,false, Error.Validation()) =>
        Errors = errors;

        public Error[] Errors { get; }
        public static ValidationResult<TValue> WithErrors(Error[] errors) => new(errors);
    }
}
