using Clinic.Domain.Exceptions;

namespace Clinic.Application.Exceptions
{
    public class UserAlreadyExistsException : ClinicException
    {
        public UserAlreadyExistsException(string email) : base($"Employee with email '{email}' already exists.")
        {
            Email = email;
        }

        public string Email { get; }
    }
}
