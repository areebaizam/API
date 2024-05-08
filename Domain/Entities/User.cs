using Domain.Primitives;

namespace Domain.Entities
{
    public class User : Entity<UserId>
    {
        public User(UserId id, string email, string name) : base(id)
        {
            Email = email;
            Name = name;
        }
        public string Email { get; private set; } = string.Empty;
        public string Name { get; private set; } = string.Empty;
    }
}
