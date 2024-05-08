using MediatR;

namespace Application.Features.UserFeatures
{
    //TODO USE User Response
    public record GetUsersQuery() : IRequest<IEnumerable<GetUserResponse>>;

}
