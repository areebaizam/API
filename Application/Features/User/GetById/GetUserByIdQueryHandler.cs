using Application.IRepositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var userId = _mapper.Map<UserId>(request.UserId);
            var user = await _repository
                .GetAsync(userId, cancellationToken);
            
            return _mapper.Map<GetUserResponse>(user);
        }
    }
}
