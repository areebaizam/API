using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.IRepositories
{
    public interface IDataContext
    {
        public DbSet<User> Users { get; set; }
    }
}
