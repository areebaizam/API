using Application.Abstractions.Data;
using Application.Abstractions.Dispatcher;
using AutoMapper;
using Domain.Entities;
using Domain.Shared;

namespace Application.Features.UserFeatures
{
    internal sealed class GetUserByIdQueryHandler(IUserRepository repository, IMapper mapper) : IQueryHandler<GetUserByIdQuery,GetUserResponse>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IUserRepository _repository = repository;

        public async Task<Result<GetUserResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var userId = _mapper.Map<UserId>(request.Id.UserId);
            var user = await _repository
                .GetByIdAsync(userId, cancellationToken);
            if (user is null)
            {
                return Result.Failure<GetUserResponse>(Error.NotFound("user", userId.Value));
            }

            return _mapper.Map<GetUserResponse>(user);
        }

    }
}
