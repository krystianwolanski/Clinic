using Clinic.Domain.Exceptions;

namespace Clinic.Application.Exceptions
{
    public class UserNotFoundException : ClinicException
    {
        public UserNotFoundException(string login) : base($"Employee with login '{login}' was not found.")
        {
            Login = login;
        }

        public string Login { get; }
    }
}
