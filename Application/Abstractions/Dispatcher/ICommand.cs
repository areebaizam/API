using Domain.Shared;
using MediatR;

namespace Application.Abstractions.Dispatcher
{
    public interface ICommand : IRequest<Result>
    {
    }
    public interface ICommand<TResponse> : IRequest<Result<TResponse>>
    {
    }
}
