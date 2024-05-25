using Domain.Shared;
using MediatR;

namespace Application.Abstractions.Dispatcher
{
    public interface IQuery<TResponse> : IRequest<Result<TResponse>>
    {
    }
}
