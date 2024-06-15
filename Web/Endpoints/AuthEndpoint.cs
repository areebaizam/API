using Application.Features.Authentication.Login;
using Application.Features.UserFeatures;
using MediatR;
using WebApi.Extensions;

namespace WebApi.Endpoints
{
    public static class AuthEndpoint
    {
        private static readonly string _baseUrl = BaseEndpoint._baseUrl + "auth";
        public static void MapAuthEndpoints(this WebApplication app)
        {
            //Base URL
            var group = app.MapGroup(_baseUrl);
            //TODO use API Routes class for paths
            group.MapPost("login", Login).WithName("Login").WithOpenApi().AllowAnonymous();
            //group.MapGet("{id}", GetByIdAsync).WithName("GetUserById").WithOpenApi();
            //group.MapPost("detail", GetDetailByIdAsync).WithName("GetUserDetailById").WithOpenApi();
            //group.MapPost("", AddAsync).WithName("AddUser").WithOpenApi();
            //group.MapPut("{id}", UpdateAsync).WithName("UpdateUser").WithOpenApi();
            //group.MapDelete("{id}", DeleteAsync).WithName("DeleteUser").WithOpenApi();
            //group.RequireAuthorization();
        }

        static async Task<IResult> Login(LoginRequest request,ISender sender, CancellationToken cancellationToken)
        {
            var response = await sender.Send(new LoginCommand(request), cancellationToken);
            return BaseEndpoint.ApiGo(response);
        }
    }
}
