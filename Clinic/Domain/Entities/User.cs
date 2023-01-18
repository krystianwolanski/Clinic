using Clinic.Domain.Enums;

namespace Clinic.Domain.Entities
{
    public abstract class User
    {
        protected User(string login, string password, Role role)
        {
            Login = login;
            Password = password;
            Role = role;
        }

        public string Login { get; }
        public string Password { get; }
        public Role Role { get; }
    }
}
