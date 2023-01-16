namespace Clinic.Domain.Exceptions
{
    public class DutyOnThisDayException : ClinicException
    {
        public DutyOnThisDayException(string pesel) : base($"Employee with pesel '{pesel}' has already duty on this day.")
        {
            Pesel = pesel;
        }

        public string Pesel { get; }
    }
}