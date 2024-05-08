using Application.IRepositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.UserFeatures
{
    internal sealed class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, IEnumerable<GetUserResponse>>
    {
        //private readonly IDataContext _context;
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public GetUsersQueryHandler(IUserRepository repository, IMapper mapper)
        {
            //_context = context;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetUserResponse>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _repository
                .GetAllAsync(cancellationToken);

            return _mapper.Map<List<GetUserResponse>>(users);
        }

        
    }
}
