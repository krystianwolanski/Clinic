using Clinic.Domain.Exceptions;

namespace Clinic.Application.Exceptions
{
    public class UserNotFoundException : ClinicException
    {
        public UserNotFoundException(string email) : base($"Employee with email '{email}' was not found.")
        {
            Email = email;
        }

        public string Email { get; }
    }
}
