namespace Clinic.Domain.Exceptions
{
    internal class MaxDutiesPerMonthException : ClinicException
    {
        public MaxDutiesPerMonthException(string pesel, int maxDutiesNumber)
            : base($"Employee with pesel '{pesel}' has excited max duties per month. " +
                  $"Max duties per month is {maxDutiesNumber}.")
        {
            Pesel = pesel;
            MaxDutiesNumber = maxDutiesNumber;
        }

        public int MaxDutiesNumber { get; }
        public string Pesel { get; }
    }
}
