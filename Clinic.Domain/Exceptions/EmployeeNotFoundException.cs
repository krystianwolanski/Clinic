namespace Clinic.Domain.Exceptions
{
    public class EmployeeNotFoundException : ClinicException
    {
        public EmployeeNotFoundException(string pesel) : base($"Employee with pesel '{pesel}' was not found.")
        {
            Pesel = pesel;
        }

        public string Pesel { get; }
    }
}
