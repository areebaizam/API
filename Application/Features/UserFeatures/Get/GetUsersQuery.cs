using MediatR;

namespace Application.Features.UserFeatures
{
    public record GetUsersQuery() : IRequest<IEnumerable<GetUsersResponse>>;

}
