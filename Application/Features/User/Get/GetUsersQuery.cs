using MediatR;

namespace Application.Features.User
{
    //TODO USE User Response
    public record GetUsersQuery() : IRequest<IEnumerable<Domain.Entities.User>>;

}
