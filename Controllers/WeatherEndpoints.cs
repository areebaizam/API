using Carter;

namespace API.Controllers
{
    public  class WeatherEndpoints : ICarterModule
    //: ICarterModule
    {
        //public  void MapProductEndpoints(this WebApplication app)
        //{
        //    var group = app.MapGroup("api/products");
        //    group.MapGet("", GetProducts).WithName("GetWeatherForecast").WithOpenApi();

        //}

        public  void AddRoutes(IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("api/weather1");

            //group.MapPost("", CreateProduct);

            group.MapGet("", GetProducts).WithName("weatherforecast");


            //group.MapGet("{id}", GetProduct).WithName(nameof(GetProduct));

            //group.MapPut("{id}", UpdateProduct).WithName(nameof(UpdateProduct));

            //group.MapDelete("{id}", DeleteProduct).WithName(nameof(DeleteProduct));
        }
        //public  void RegisterTodoItemsEndpoints(this WebApplication app)
        //{
        //    app.MapGet("/hello", () =>
        //    {
        //        return "Hello, World!";

        //    });

        //}
        public static async Task<IResult> GetProducts()
        //public static Task<Results<Ok<WeatherForecast[]>> GetProducts()
        {
            var summaries = new[]
            {
                 "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
             };
            var forecast = Enumerable.Range(1, 5).Select(index =>
       new WeatherForecast
       (

           DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
           Random.Shared.Next(-20, 55),
           summaries[Random.Shared.Next(summaries.Length)]
       ))
       .ToArray();

            return Results.Ok(forecast);

        }

    }



    record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
    {
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }
}
