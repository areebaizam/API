using Application.Features.UserFeatures;
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

        static async Task<Results<Ok<IEnumerable<GetUserResponse>>, NoContent>> GetAsync(ISender sender, CancellationToken cancellationToken)
        {
            var response = await sender.Send(new GetUsersQuery(), cancellationToken);
            return response.Count() > 0 ? TypedResults.Ok(response) : TypedResults.NoContent();
        } 
        
        static async Task<Results<Ok<GetUserResponse>, NoContent>> GetByIdAsync(Guid id, ISender sender, CancellationToken cancellationToken)
        {
            var response = await sender.Send(new GetUserByIdQuery(new GetUserRequest(id)), cancellationToken);
            return response is GetUserResponse? TypedResults.Ok(response):TypedResults.NoContent();
        } 
        
        static async Task<Results<Ok<GetUserResponse>, NoContent>> PostByIdAsync(GetUserRequest request,ISender sender, CancellationToken cancellationToken)
        {
            var response = await sender.Send(new GetUserByIdQuery(request), cancellationToken);
            return response is GetUserResponse ? TypedResults.Ok(response) : TypedResults.NoContent();
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
    }
}
