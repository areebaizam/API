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
        public static void MapUserEndpoints(this WebApplication app)
        {
            //Base URL
            var group = app.MapGroup("api/user");
            group.MapGet("", GetAsync).WithName("GetAllUsers").WithOpenApi();
            group.MapGet("{id}", GetByIdAsync).WithName("GetUserById").WithOpenApi();
            group.MapPost("", PostByIdAsync).WithName("PostUserById").WithOpenApi();
        }

        static async Task<Results<Ok<IEnumerable<GetUserResponse>>, NotFound<string>>> GetAsync(ISender sender, CancellationToken cancellationToken)
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

        static async Task<Results<Ok<GetUserResponse>, NotFound<string>>> PostByIdAsync(GetUserRequest request, ISender sender, CancellationToken cancellationToken)
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
