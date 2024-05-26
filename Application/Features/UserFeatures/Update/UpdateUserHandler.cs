using Application.Abstractions.Data;
using Application.Abstractions.Dispatcher;
using Domain.Entities;
using Domain.Shared;

namespace Application.Features.UserFeatures
{
    public record UpdateUserCommand(UserId Id, UpdateUserRequest User) : ICommand;

    public sealed class UpdateUserHandler(IUserRepository repository, IUnitOfWork unitOfWork) : ICommandHandler<UpdateUserCommand>
    {
        private readonly IUserRepository _repository = repository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Result> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            //TODO Move this code to common method
            var user = await _repository.GetByIdAsync(request.Id, cancellationToken);
            if (user == null)
            {
                return Error.NotFound("user", request.Id.Value);
            }

            var updatedUser = new User(request.Id, 
                string.IsNullOrWhiteSpace(request.User.Email)? user.Email : request.User.Email,
                string.IsNullOrWhiteSpace(request.User.Name) ? user.Name : request.User.Name);

            _repository.Update(updatedUser);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
