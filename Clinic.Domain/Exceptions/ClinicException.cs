namespace Clinic.Domain.Exceptions
{
    public abstract class ClinicException : Exception
    {
        public ClinicException(string message) : base(message)
        {
        }
    }
}
