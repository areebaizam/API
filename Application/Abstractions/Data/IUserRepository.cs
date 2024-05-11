using Domain.Entities;

namespace Application.Abstractions.Data
{
    public interface IUserRepository : IRepository<User, UserId>
    {
        public Task<bool> IsEmailUniqueAsync(string email);
    }
}
