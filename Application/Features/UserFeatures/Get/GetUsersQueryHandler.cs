using Application.Abstractions.Data;
using Application.Abstractions.Dispatcher;
using AutoMapper;
using Domain.Shared;

namespace Application.Features.UserFeatures
{
    public record GetUsersQuery() : IQuery<IEnumerable<GetUsersResponse>>;
    internal sealed class GetUsersQueryHandler(IUserRepository repository, IMapper mapper) : IQueryHandler<GetUsersQuery, IEnumerable<GetUsersResponse>>
    {
        //private readonly IDataContext _context;
        private readonly IUserRepository _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<Result<IEnumerable<GetUsersResponse>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _repository
                .GetAsync(cancellationToken);

            if (users == default || users.Count == 0)
            {
                return Error.NotFound("user");
            }

            return _mapper.Map<List<GetUsersResponse>>(users);
        }

        
    }
}
