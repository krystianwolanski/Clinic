using Clinic.Domain.Exceptions;

namespace Clinic.Application.Exceptions
{
    public class IncorrectPasswordException : ClinicException
    {
        public IncorrectPasswordException() : base("Uncorrect login or password.")
        {
        }
    }
}
