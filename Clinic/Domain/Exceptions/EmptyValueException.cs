namespace Clinic.Domain.Exceptions
{
    public class EmptyValueException : ClinicException
    {
        public EmptyValueException(string name) : base($"{name} cannot be an empty value.")
        {
        }
    }
}
