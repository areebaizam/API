using Domain.Entities;
using Domain.Primitives;

namespace Application.Abstractions.Data
{
    public interface IUserRepository : IRepository<User, UserId>
    {
        public Task<bool> IsEmailUniqueAsync(string email, CancellationToken cancellationToken);
        public Task<Maybe<User>> GetByEmailAsync(string email, CancellationToken cancellationToken);
    }
}
