using Domain.Entities;
using Application.IRepositories;
using Microsoft.EntityFrameworkCore;
namespace Persistence.Repositories
{
    public class UserRepository : Repository<User, UserId>, IUserRepository
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
