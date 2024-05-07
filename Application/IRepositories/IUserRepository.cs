using Domain.Entities;

namespace Application.IRepositories
{
    public interface IUserRepository : IRepository<User, UserId>
    {
        public Task<bool> IsEmailUniqueAsync(string email);
    }
}
