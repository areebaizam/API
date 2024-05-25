using Application.Abstractions.Data;
using Application.Abstractions.Dispatcher;
using Application.Common.Exceptions;
using AutoMapper;
using Domain.Entities;
using Domain.Shared;
using MediatR;

namespace Application.Features.UserFeatures
{

    public sealed class UpdateUserHandler : ICommandHandler<UpdateUserCommand, Unit>
    {
        private readonly IUserRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateUserHandler(IUserRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<Unit>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            //TODO Move this code to common method
            var user = await _repository.GetByIdAsync(request.Id, cancellationToken);
            if (user == null)
            {
                return Result.Failure<Unit>(Error.NotFound("user", request.Id.Value));
            }

            var updatedUser = new User(request.Id, 
                string.IsNullOrWhiteSpace(request.User.Email)? user.Email : request.User.Email,
                string.IsNullOrWhiteSpace(request.User.Name) ? user.Name : request.User.Name);

            _repository.Update(updatedUser);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
