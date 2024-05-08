using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Abstractions.Data
{
    public interface IDataContext
    {
        public DbSet<User> Users { get; set; }
    }
}
