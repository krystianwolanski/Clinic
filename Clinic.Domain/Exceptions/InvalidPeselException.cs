using Clinic.Domain.Exceptions;

namespace Clinic.Domain.ValueObjects
{
    public class InvalidPeselException : ClinicException
    {
        public InvalidPeselException() : base("Invalid value of pesel.")
        {
        }
    }
}