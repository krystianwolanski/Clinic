using Clinic.Domain.Enums;
using Clinic.Domain.ValueObjects;

namespace Clinic.Domain.Entities
{
    public abstract class User
    {
        protected User(Login login, Password password, Role role)
        {
            Login = login;
            Password = password;
            Role = role;
        }

        public Login Login { get; }
        public Password Password { get; }
        public Role Role { get; }
    }
}
