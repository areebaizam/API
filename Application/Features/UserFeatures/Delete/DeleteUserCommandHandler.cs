using Application.Abstractions.Data;
using Application.Abstractions.Dispatcher;
using Application.Common.Exceptions;
using Domain.Entities;
using Domain.Shared;
using MediatR;

namespace Application.Features.UserFeatures
{
    public sealed class DeleteUserCommandHandler : ICommandHandler<DeleteUserCommand,Unit>
    {
        private readonly IUserRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteUserCommandHandler(IUserRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Unit>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByIdAsync(request.userId,cancellationToken);

            if (user is null)
            {
                return Result.Failure<Unit>(Error.NotFound("user", request.userId.Value));
            }

            _repository.Delete(user);

           await _unitOfWork.SaveChangesAsync(cancellationToken);
           return Unit.Value;
        }

    }
}
