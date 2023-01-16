namespace Clinic.Domain.Exceptions
{
    public class EmptyPeselException : ClinicException
    {
        public EmptyPeselException() : base("Pesel cannot be an empty value.")
        {
        }
    }
}
