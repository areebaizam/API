using Domain.Entities;

namespace Application.Abstractions.Data
{
    public interface IUserRepository : IRepository<User, UserId, Guid>
    {
        public Task<bool> IsEmailUniqueAsync(string email);
    }
}
