using Application.Abstractions.Authentication;
using Application.Abstractions.Data;
using Application.Abstractions.Dispatcher;
using Domain.Entities;
using Domain.Primitives;
using Domain.Shared;

namespace Application.Features.Authentication.Login
{
    public sealed record LoginCommand(LoginRequest Credentials) : ICommand<TokenResponse>;
    public sealed class LoginCommandHandler(IUserRepository repository, IJwtProvider jwtProvider) : ICommandHandler<LoginCommand, TokenResponse>
    {
        private readonly IUserRepository _repository = repository;
        private readonly IJwtProvider _jwtProvider = jwtProvider;

        public async Task<Result<TokenResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {

            Maybe<User> user = await _repository.GetByEmailAsync(request.Credentials.Email, cancellationToken);
            if (!user.HasValue)
            {
                return Error.Credentials();
            }

            var claim = new JwtClaim {
                NameIdentifier = user.Value.Id.Value.ToString(),
                Name = user.Value.Name
            };

            return new TokenResponse(_jwtProvider.WriteToken(claim));
        }
    }
 
}
