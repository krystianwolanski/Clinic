namespace Clinic.Domain.Exceptions
{
    public class EmployeeAlreadyExistsException : ClinicException
    {
        public EmployeeAlreadyExistsException(string pesel) : base($"Employee with pesel '{pesel}' already exists.")
        {
            Pesel = pesel;
        }

        public string Pesel { get; }
    }
}
