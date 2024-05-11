using Application.Abstractions.Data;
using Application.Common.Exceptions;
using Domain.Entities;
using MediatR;

namespace Application.Features.UserFeatures
{
    public sealed class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand,Unit>
    {
        private readonly IUserRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteUserCommandHandler(IUserRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByIdAsync(request.userId,cancellationToken);

            if (user is null)
            {
                throw new EntityNotFoundException<Guid>("user", request.userId.Value);
            }

            _repository.Delete(user);

           await _unitOfWork.SaveChangesAsync(cancellationToken);
           return Unit.Value;
        }

    }
}
