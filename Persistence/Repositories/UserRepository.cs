using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Application.Abstractions.Data;
using Domain.Primitives;
namespace Persistence.Repositories
{
    public class UserRepository(DataContext dbContext) : Repository<User, UserId>(dbContext), IUserRepository
    {
        public async Task<bool> IsEmailUniqueAsync(string email, CancellationToken cancellationToken)
        {
            return !await DbSet.AnyAsync(c => c.Email == email, cancellationToken);
        }
        //TODO use Mabe insetead of ? use event project
        public async Task<Maybe<User>> GetByEmailAsync(string email, CancellationToken cancellationToken)
        {
            return await DbSet.FirstOrDefaultAsync(c => c.Email == email,cancellationToken);
        }
    }
}
