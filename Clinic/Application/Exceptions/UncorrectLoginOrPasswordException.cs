using Clinic.Domain.Exceptions;

namespace Clinic.Application.Exceptions
{
    public class UncorrectLoginOrPasswordException : ClinicException
    {
        public UncorrectLoginOrPasswordException() : base("Uncorrect login or password.")
        {
        }
    }
}
