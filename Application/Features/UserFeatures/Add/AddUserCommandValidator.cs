using Application.Abstractions.Data;
using FluentValidation;

namespace Application.Features.UserFeatures
{
    public sealed class AddUserCommandValidator : AbstractValidator<AddUserCommand>
    {
        public AddUserCommandValidator(IUserRepository repository)
        {
            RuleFor(c => c.user.Email).MustAsync(async (email, _) =>
            {
                return await repository.IsEmailUniqueAsync(email);
            }).WithMessage("The email must be unique");
        }
    }
}
