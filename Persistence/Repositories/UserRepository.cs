using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Application.Abstractions.Data;
namespace Persistence.Repositories
{
    public class UserRepository : Repository<User, UserId, Guid>, IUserRepository
    {

        public UserRepository(DataContext dbContext) : base(dbContext)
        {

        }

        public async Task<bool> IsEmailUniqueAsync(string email)
        {
            return !await DbSet.AnyAsync(c => c.Email == email);
        }
    }
}
