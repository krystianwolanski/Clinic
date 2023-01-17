namespace Clinic.Domain.Exceptions
{
    public class DutyOnThisDayException : ClinicException
    {
        public DutyOnThisDayException(string email) : base($"Employee with email '{email}' has already duty on this day.")
        {
            Email = email;
        }

        public string Email { get; }
    }
}