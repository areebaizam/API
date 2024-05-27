using Application.Features.UserFeatures;
using Domain.Entities;
using Domain.Shared;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using WebApi.Extensions;

namespace Web.Endpoints
{
    public static class UserEndpoint
    {
        private static readonly string _baseUrl = BaseEndpoint._baseUrl + "user";
        public static void MapUserEndpoints(this WebApplication app)
        {
            //Base URL
            var group = app.MapGroup(_baseUrl);
            group.MapGet("", GetAsync).WithName("GetAllUsers").WithOpenApi();
            group.MapGet("{id}", GetByIdAsync).WithName("GetUserById").WithOpenApi();
            group.MapPost("detail", GetDetailByIdAsync).WithName("GetUserDetailById").WithOpenApi();
            group.MapPost("", AddAsync).WithName("AddUser").WithOpenApi();
            group.MapPut("{id}", UpdateAsync).WithName("UpdateUser").WithOpenApi();
            group.MapDelete("{id}", DeleteAsync).WithName("DeleteUser").WithOpenApi();
        }

        static async Task<IResult> GetAsync(ISender sender, CancellationToken cancellationToken)
        {
            var response = await sender.Send(new GetUsersQuery(), cancellationToken);
            return BaseEndpoint.ApiGo(response);
        }

        static async Task<IResult> GetByIdAsync(Guid id, ISender sender, CancellationToken cancellationToken)
        {
            var response = await sender.Send(new GetUserByIdQuery(new GetUserRequest(id)), cancellationToken);
            return BaseEndpoint.ApiGo(response);
        }

        static async Task<IResult> GetDetailByIdAsync(GetUserRequest request, ISender sender, CancellationToken cancellationToken)
        {
            var response = await sender.Send(new GetUserByIdQuery(request), cancellationToken);
            return BaseEndpoint.ApiGo(response);
        }
        static async Task<IResult> AddAsync(AddUserRequest request, ISender sender, CancellationToken cancellationToken)
        {
            var response = await sender.Send(new AddUserCommand(request), cancellationToken);
            return BaseEndpoint.ApiGo(response);
        }
        static async Task<IResult> DeleteAsync(Guid id, ISender sender, CancellationToken cancellationToken)
        {
            var response = await sender.Send(new DeleteUserCommand(new UserId(id)), cancellationToken);
            return BaseEndpoint.ApiGo(response);
        }

        static async Task<IResult> UpdateAsync(Guid id, UpdateUserRequest request, ISender sender, CancellationToken cancellationToken)
        {
            var response = await sender.Send(new UpdateUserCommand(new UserId(id),request), cancellationToken);
            return BaseEndpoint.ApiGo(response);
        }
    }
}
