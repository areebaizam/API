using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
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
