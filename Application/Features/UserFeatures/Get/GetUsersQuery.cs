using Application.Abstractions.Dispatcher;

namespace Application.Features.UserFeatures
{
    public record GetUsersQuery() : IQuery<IEnumerable<GetUsersResponse>>;

}
