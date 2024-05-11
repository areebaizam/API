using Application.Abstractions.Data;
using Application.Common.Exceptions;
using AutoMapper;
using Domain.Entities;
using Domain.Primitives;
using MediatR;

namespace Application.Features.UserFeatures
{
    internal sealed class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery,GetUserResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _repository;

        public GetUserByIdQueryHandler(IUserRepository repository, IMapper mapper)
        {
            //_context = context;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetUserResponse> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var userId = _mapper.Map<UserId>(request.id);
            var user = await _repository
                .GetByIdAsync(userId, cancellationToken);

            if (user is null)
            {
                throw new EntityNotFoundException<Guid>("user",userId.Value);
            }

            return _mapper.Map<GetUserResponse>(user);
        }
    }
}
