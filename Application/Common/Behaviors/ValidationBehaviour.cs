﻿using Application.Common.Exceptions;
using Domain.Shared;
using FluentValidation;
using MediatR;


namespace Application.Common.Behaviors
{
    public sealed class ValidationBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators) : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : Result
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators = validators;

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            // Validate
            //var context = new ValidationContext<TRequest>(request);

            //var validationFailures = await Task.WhenAll(
            //    _validators.Select(validator => validator.ValidateAsync(context)));
            if (!_validators.Any())
            {
                return await next();
            }

            Error[] errors = _validators
            .Select(validator => validator.Validate(request))
            .SelectMany(validationResult => validationResult.Errors)
            .Where(validationFailure => validationFailure is not null)
            .Select(failure => Error.Failure(
                failure.PropertyName,
                failure.ErrorMessage))
            .Distinct()
            .ToArray();

            if (errors.Length > 0)
                return CreateValidationResult<TResponse>(errors);

            return await next();
        }

        private static TResult CreateValidationResult<TResult>(Error[] errors)
            where TResult : Result
        {
            if (typeof(TResult) == typeof(Result))
            {
                return (ValidationResult.WithErrors(errors) as TResult)!;
            }

            object validationResult = typeof(ValidationResult<>)
                .GetGenericTypeDefinition()
                .MakeGenericType(typeof(TResult).GenericTypeArguments[0])
                .GetMethod(nameof(ValidationResult.WithErrors))!
                .Invoke(null, [errors])!;

            return (TResult)validationResult;
        }
    }
}
