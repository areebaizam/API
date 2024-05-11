using Application.Abstractions.Data;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.UserFeatures
{
    public sealed class AddUserCommandHandler : IRequestHandler<AddUserCommand,AddUserResponse>
    {
        private readonly IUserRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddUserCommandHandler(IUserRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AddUserResponse> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request.user);

            await _repository.AddAsync(user, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return _mapper.Map<AddUserResponse>(user.Id);
        }
    }
}
