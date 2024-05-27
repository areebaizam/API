namespace Domain.Shared
{
    public record Error {
        internal Error(string code, string message)
        {
            Code = code;
            Message = message;
        }
        public string Code { get; }
        public string Message { get; }

        public static readonly Error None = new(ErrorType.None, string.Empty);
        public static readonly Error NullValue = new(ErrorType.NullValue, "Null value was provided.");

        //TODO Use strongly Typed Id
        public static Error NotFound(string entity, object key) =>
            new(ErrorType.NotFound, $"The {entity} with id {key} was not found.");
        public static Error NotFound(string entity) =>
            new(ErrorType.NotFound, $"No {entity} data found");
        public static Error Validation() =>
            new(ErrorType.Validation, "Validation Error Occured");
        public static Error Conflict(string entity, object key) =>
            new(ErrorType.Validation, $"The {entity} with id {key} already exists.");
        public static Error Failure(string propertyName, string errorMessage) =>
            new(propertyName, errorMessage);
    }

    public static class ErrorType
    {
        public const string None = nameof(None);
        public const string NullValue = nameof(NullValue);
        public const string NotFound = nameof(NotFound);
        public const string Validation = nameof(Validation);
        public const string Conflict = nameof(Conflict);
        public const string Failure = nameof(Failure);
    }

}
