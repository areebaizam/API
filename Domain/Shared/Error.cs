using System.Collections.Frozen;

namespace Domain.Shared
{
    public record Error {
        internal Error(string code, string message, ErrorType type)
        {
            Code = code;
            Message = message;
            Type = type;
        }
        public string Code { get; }
        public string Message { get; }
        public ErrorType Type { get; }

        public static readonly Error None = new(string.Empty, string.Empty, ErrorType.None);
        public static readonly Error NullValue = new("Null", "Null value was provided.", ErrorType.NullValue);

        //TODO Use strongly Typed Id
        public static Error NotFound(string entity, object key) =>
            new("Not Found", $"The {entity} with id {key} was not found.", ErrorType.NotFound);
        public static Error NotFound(string entity) =>
            new("Not Found", $"No {entity} data found", ErrorType.NotFound);
        public static Error Validation() =>
            new("Bad Request", "Validation Error Occured", ErrorType.Validation);
        public static Error Conflict(string entity, object key) =>
            new("Conflict Occured", $"The {entity} with id {key} already exists.", ErrorType.Conflict);
        public static Error Failure(string propertyName, string errorMessage) =>
            new(propertyName, errorMessage, ErrorType.Failure);

        //Implicit Operator
        //public static implicit operator Result(Error error) => Result.Failure(error);
        //public static implicit operator Result<TValue>(Error error) => Result.Failure(error);

    }

    public enum ErrorType {
        None,
        NullValue,
        NotFound,
        Validation,
        Conflict,
        Failure,
    }

}
