namespace Clinic.Domain.Exceptions
{
    public class DutyOnThisDayException : ClinicException
    {
        public DutyOnThisDayException(string login) : base($"Employee with login '{login}' has already duty on this day.")
        {
            Login = login;
        }

        public string Login { get; }
    }
}