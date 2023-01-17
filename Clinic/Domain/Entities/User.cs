using Clinic.Domain.Enums;

namespace Clinic.Domain.Entities
{
    public abstract class User
    {
        protected User(string email, string password, Role role)
        {
            Email = email;
            Password = password;
            Role = role;
        }

        public string Email { get; }
        public string Password { get; }
        public Role Role { get; }
    }
}
