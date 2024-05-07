using Domain.Primitives;

namespace Domain.Entities
{
    public class User : Entity<UserId>
    {
        public User(UserId id, string email, string name) : base(id)
        {
            //Id = id;
            Email = email;
            Name = name;
        }
        //public UserId Id { get; private set; } = UserId.Empty;
        public string Email { get; private set; } = string.Empty;
        public string Name { get; private set; } = string.Empty;
    }
}
