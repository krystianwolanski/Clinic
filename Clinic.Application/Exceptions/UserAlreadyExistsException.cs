using Clinic.Domain.Exceptions;

namespace Clinic.Application.Exceptions
{
    public class UserAlreadyExistsException : ClinicException
    {
        public UserAlreadyExistsException(string login) : base($"User with login '{login}' already exists.")
        {
            Login = login;
        }

        public string Login { get; }
    }
}
