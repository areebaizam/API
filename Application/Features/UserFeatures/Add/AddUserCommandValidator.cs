using FluentValidation;

namespace Application.Features.UserFeatures
{
    public sealed class AddUserCommandValidator : AbstractValidator<AddUserCommand>
    {
        public AddUserCommandValidator()
        {
            RuleFor(c => c.User.Email).NotEmpty().NotNull()
                .WithMessage("Email is required");
            RuleFor(c => c.User.Email).EmailAddress()
                .WithMessage("Email is invalid");
        }

    }
}
