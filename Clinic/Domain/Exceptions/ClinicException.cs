namespace Clinic.Domain.Exceptions
{
    public abstract class ClinicException : Exception
    {
        protected ClinicException(string message) : base(message)
        {
        }
    }
}
