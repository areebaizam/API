using Application.Abstractions.Data;
using Application.Abstractions.Dispatcher;
using Domain.Entities;
using Domain.Shared;

namespace Application.Features.UserFeatures
{
    public record DeleteUserCommand(UserId UserId) : ICommand;
    public sealed class DeleteUserCommandHandler(IUserRepository repository, IUnitOfWork unitOfWork) : ICommandHandler<DeleteUserCommand>
    {
        private readonly IUserRepository _repository = repository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Result> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByIdAsync(request.UserId,cancellationToken);

            if (user is null)
            {
                return Error.NotFound("user", request.UserId.Value);
            }

            _repository.Delete(user);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }

    }
}
