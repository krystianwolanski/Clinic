namespace Clinic.Domain.Exceptions
{
    public class DutyTheDayAfterAnotherException : ClinicException
    {
        public DutyTheDayAfterAnotherException(string login) : base($"Employee with login '{login}' has a duty day earlier.")
        {
            Login = login;
        }

        public string Login { get; }
    }
}