using Microsoft.EntityFrameworkCore;
using Application.Abstractions.Data;
using Domain.Entities;

namespace Persistence
{
    public class DataContext(DbContextOptions<DataContext> options) : DbContext(options), IDataContext, IUnitOfWork
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<User>()
                .Property(user=>user.Id)
                .HasConversion(id => id.Value, value => new(value));
        }
        public DbSet<User> Users { get; set; }
    }
}
