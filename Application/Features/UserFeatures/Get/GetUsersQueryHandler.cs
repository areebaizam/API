using Application.Abstractions.Data;
using Application.Common.Exceptions;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.UserFeatures
{
    internal sealed class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, IEnumerable<GetUsersResponse>>
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

        public async Task<IEnumerable<GetUsersResponse>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _repository
                .GetAsync(cancellationToken);

            if (users.Count() == 0)
            {
                throw new NoContentException("user");
            }

            return _mapper.Map<List<GetUsersResponse>>(users);
        }

        
    }
}
