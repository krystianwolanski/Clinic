namespace Clinic.Domain.Exceptions
{
    public class DoctorWithThisSpecialtyAlreadyOnDutyException : ClinicException
    {
        public DoctorWithThisSpecialtyAlreadyOnDutyException(DateOnly dutyDate)
            : base($"There is a doctor with this specialty on a duty on day - '{dutyDate}'.")
        {
            DutyDate = dutyDate;
        }

        public DateOnly DutyDate { get; }
    }
}
