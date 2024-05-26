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

        public static readonly Error None = new(string.Empty, string.Empty);
        public static readonly Error NullValue = new("Null", "Null value was provided.");

        //TODO Use strongly Typed Id
        public static Error NotFound(string entity, object key) =>
            new("Not Found", $"The {entity} with id {key} was not found.");
        public static Error NotFound(string entity) =>
            new("Not Found", $"No {entity} data found");
        public static Error Validation() =>
            new("Bad Request", "Validation Error Occured");
        public static Error Conflict(string entity, object key) =>
            new("Conflict Occured", $"The {entity} with id {key} already exists.");
        public static Error Failure(string propertyName, string errorMessage) =>
            new(propertyName, errorMessage);
    }
}
