using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories;
using Application.Abstractions.Data;

namespace Persistence
{
    public static class ServiceExtensions
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("Database")));

            services.AddScoped<IDataContext>(sp =>
            sp.GetRequiredService<DataContext>());
            
            services.AddScoped<IUnitOfWork>(sp =>
            sp.GetRequiredService<DataContext>());

            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
