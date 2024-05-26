using Application.Abstractions.Data;
using Application.Abstractions.Dispatcher;
using AutoMapper;
using Domain.Entities;
using Domain.Shared;

namespace Application.Features.UserFeatures
{
    public sealed record AddUserCommand(AddUserRequest User) : ICommand<AddUserResponse>;
    public sealed class AddUserCommandHandler(IUserRepository repository, IUnitOfWork unitOfWork, IMapper mapper) : ICommandHandler<AddUserCommand,AddUserResponse>
    {
        private readonly IUserRepository _repository = repository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;

        public async Task<Result<AddUserResponse>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request.User);

            await _repository.AddAsync(user, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return _mapper.Map<AddUserResponse>(user.Id);
        }
    }
}
