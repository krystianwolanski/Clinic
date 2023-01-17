namespace Clinic.Domain.Exceptions
{
    internal class MaxDutiesPerMonthException : ClinicException
    {
        public MaxDutiesPerMonthException(string email, int maxDutiesNumber)
            : base($"Employee with email '{email}' has excited max duties per month. " +
                  $"Max duties per month is {maxDutiesNumber}.")
        {
            Email = email;
            MaxDutiesNumber = maxDutiesNumber;
        }

        public string Email { get; }
        public int MaxDutiesNumber { get; }
    }
}
