using Application.Common.Exceptions;
using Application.Features.UserFeatures;
using Domain.Entities;
using Domain.Primitives;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Web.Endpoints
{
    public static class UserEndpoint
    {
        private static string _baseUrl = "api/user";
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

        static async Task<Results<Ok<IEnumerable<GetUsersResponse>>, NotFound<string>>> GetAsync(ISender sender, CancellationToken cancellationToken)
        {
            try
            {
                var response = await sender.Send(new GetUsersQuery(), cancellationToken);

                return TypedResults.Ok(response);
            }

            catch (NoContentException ex)
            {
                return TypedResults.NotFound(ex.Message);
            }
        }

        static async Task<Results<Ok<GetUserResponse>, NotFound<string>>> GetByIdAsync(Guid id, ISender sender, CancellationToken cancellationToken)
        {
            try
            {
                var response = await sender.Send(new GetUserByIdQuery(new GetUserRequest(id)), cancellationToken);
                return TypedResults.Ok(response);
            }
            catch (EntityNotFoundException<Guid> ex)
            {
                return TypedResults.NotFound(ex.Message);
            }
        }

        static async Task<Results<Ok<GetUserResponse>, NotFound<string>>> GetDetailByIdAsync(GetUserRequest request, ISender sender, CancellationToken cancellationToken)
        {
            try
            {
                var response = await sender.Send(new GetUserByIdQuery(request), cancellationToken);
                return TypedResults.Ok(response);
            }
            catch (EntityNotFoundException<Guid> ex)
            {
                return TypedResults.NotFound(ex.Message);
            }
        }
        static async Task<Results<Created<AddUserResponse>, BadRequest<string>>> AddAsync(AddUserRequest request, ISender sender, CancellationToken cancellationToken)
        {
            //try
            //{
                var response = await sender.Send(new AddUserCommand(request), cancellationToken);
                var locationUri =$"{_baseUrl}/{response.UserId}";
                return TypedResults.Created(locationUri, response);
            //}
            //catch (EntityNotFoundException<Guid> ex)
            //{
            //    return TypedResults.NotFound(ex.Message);
            //}
        }

        static async Task<Results<NoContent, NotFound<string>>> DeleteAsync(Guid id, ISender sender, CancellationToken cancellationToken)
        {
            try
            {
                await sender.Send(new DeleteUserCommand(new UserId(id)), cancellationToken);
                return TypedResults.NoContent();
            }
            catch (EntityNotFoundException<Guid> ex)
            {
                return TypedResults.NotFound(ex.Message);
            }
        }

        static async Task<Results<NoContent, NotFound<string>>> UpdateAsync(Guid id, UpdateUserRequest request, ISender sender, CancellationToken cancellationToken)
        {
            try
            {
                var response = await sender.Send(new UpdateUserCommand(new UserId(id),request), cancellationToken);
                return TypedResults.NoContent();
            }
            catch (EntityNotFoundException<Guid> ex)
            {
                return TypedResults.NotFound(ex.Message);
            }
        }
    }
}

        
        //static async Task<IResult> GetUserAsync(int id, DataContext db)
        //{
        //    return await db.Users.FindAsync(id)
        //        is Users user
        //            ? TypedResults.Ok(todo)
        //            : TypedResults.NotFound();
        //}

        //static async Task<IResult> CreateTodo(Todo todo, TodoDb db)
        //{
        //    db.Todos.Add(todo);
        //    await db.SaveChangesAsync();

        //    return TypedResults.Created($"/todoitems/{todo.Id}", todo);
        //}

        //static async Task<IResult> UpdateTodo(int id, Todo inputTodo, TodoDb db)
        //{
        //    var todo = await db.Todos.FindAsync(id);

        //    if (todo is null) return TypedResults.NotFound();

        //    todo.Name = inputTodo.Name;
        //    todo.IsComplete = inputTodo.IsComplete;

        //    await db.SaveChangesAsync();

        //    return TypedResults.NoContent();
        //}

        //static async Task<IResult> DeleteTodo(int id, TodoDb db)
        //{
        //    if (await db.Todos.FindAsync(id) is Todo todo)
        //    {
        //        db.Todos.Remove(todo);
        //        await db.SaveChangesAsync();
        //        return TypedResults.NoContent();
        //    }

        //    return TypedResults.NotFound();
        //}
//    }
//}
