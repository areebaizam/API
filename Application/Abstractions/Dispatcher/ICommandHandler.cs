using Domain.Shared;
using MediatR;

namespace Application.Abstractions.Dispatcher
{
    //Without Content
    public interface ICommand : IRequest<Result>
    {
    }
    public interface ICommandHandler<TCommand> : IRequestHandler<TCommand, Result>
    where TCommand : ICommand
    {
    }

    //With Content
    public interface ICommand<TResponse> : IRequest<Result<TResponse>>
    {
    }
    public interface ICommandHandler<TCommand, TResponse> : IRequestHandler<TCommand, Result<TResponse>>
    where TCommand : ICommand<TResponse>
    {
    }
}
