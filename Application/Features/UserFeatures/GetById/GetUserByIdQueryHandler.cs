using Application.Abstractions.Authentication;
using Application.Abstractions.Data;
using Application.Abstractions.Dispatcher;
using AutoMapper;
using Domain.Entities;
using Domain.Primitives;
using Domain.Shared;

namespace Application.Features.UserFeatures
{
    public sealed record GetUserByIdQuery(GetUserRequest Id) : IQuery<GetUserResponse>;
    internal sealed class GetUserByIdQueryHandler(IUserRepository repository, IMapper mapper, IClaimsPrincipalProvider provider) : IQueryHandler<GetUserByIdQuery,GetUserResponse>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IUserRepository _repository = repository;
        private readonly IClaimsPrincipalProvider _provider = provider;

        public async Task<Result<GetUserResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            UserId userId = _mapper.Map<UserId>(request.Id.UserId);
            Maybe<User> user = await _repository
                .GetByIdAsync(userId, cancellationToken);
            if (!user.HasValue)
            {
                return Error.NotFound("user", userId.Value);
            }

            return _mapper.Map<GetUserResponse>(user.Value);
        }

    }
}
