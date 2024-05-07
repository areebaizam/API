using Application.IRepositories;
using Domain.Entities;
using MediatR;

namespace Application.Features.User
{
    internal sealed class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, IEnumerable<Domain.Entities.User>>
    {
        //private readonly IDataContext _context;
        private readonly IUserRepository _repository;

        public GetUsersQueryHandler(IUserRepository repository)
        {
            //_context = context;
            _repository = repository;
        }

        public async Task<IEnumerable<Domain.Entities.User>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            return await _repository
                .GetAllAsync(cancellationToken);
        }
    }
}
