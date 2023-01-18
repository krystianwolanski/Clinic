namespace Clinic.Domain.Exceptions
{
    internal class MaxDutiesPerMonthException : ClinicException
    {
        public MaxDutiesPerMonthException(string login, int maxDutiesNumber)
            : base($"Employee with login '{login}' has excited max duties per month. " +
                  $"Max duties per month is {maxDutiesNumber}.")
        {
            Login = login;
            MaxDutiesNumber = maxDutiesNumber;
        }

        public string Login { get; }
        public int MaxDutiesNumber { get; }
    }
}
