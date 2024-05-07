using Application.Features.User;
using MediatR;

namespace Web.Endpoints
{
    public static class UserEndpoint
    {
        public static void MapUserEndpoints(this WebApplication app)
        {
            //Base URL
            var group = app.MapGroup("api/user");
            group.MapGet("", GetUsersAsync).WithName("GetAllUsers").WithOpenApi();
        }

        static async Task<IResult> GetUsersAsync(ISender sender, CancellationToken cancellationToken)
        {
            var response = await sender.Send(new GetUsersQuery(), cancellationToken);
            //IUserRepository _repository = new UserRepository(db);
            return TypedResults.Ok(response);
            //return TypedResults.Ok(await db.Users.ToArrayAsync());
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
