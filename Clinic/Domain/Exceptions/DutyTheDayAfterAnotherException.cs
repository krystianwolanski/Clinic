namespace Clinic.Domain.Exceptions
{
    public class DutyTheDayAfterAnotherException : ClinicException
    {
        public DutyTheDayAfterAnotherException(string email) : base($"Employee with email '{email}' has a duty day earlier.")
        {
            Email = email;
        }

        public string Email { get; }
    }
}