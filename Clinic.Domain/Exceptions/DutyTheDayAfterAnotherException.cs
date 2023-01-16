namespace Clinic.Domain.Exceptions
{
    public class DutyTheDayAfterAnotherException : ClinicException
    {
        public DutyTheDayAfterAnotherException(string pesel) : base($"Employee with pesel '{pesel}' has a duty day earlier.")
        {
            Pesel = pesel;
        }

        public string Pesel { get; }
    }
}