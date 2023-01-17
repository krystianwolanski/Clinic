using Clinic.Domain.Exceptions;
using Clinic.Domain.ValueObjects;

namespace Clinic.Domain.Entities
{
    public class Doctor : Employee
    {
        private readonly IEnumerable<Doctor> _allDoctors;
        private readonly string _specialty;

        public Doctor(
            IEnumerable<Doctor> allDoctors,
            Pesel pesel,
            string firstName,
            string lastName,
            string specialty) : base(pesel, firstName, lastName)
        {
            _allDoctors = allDoctors;
            _specialty = specialty;
        }

        public override void AddDuty(DateOnly duty)
        {
            if (IsThereADoctorWithThisSpecialtyOnDuty(duty))
            {
                throw new DoctorWithThisSpecialtyAlreadyOnDutyException(duty);
            }

            base.AddDuty(duty);
        }

        private bool IsThereADoctorWithThisSpecialtyOnDuty(DateOnly date)
        {
            return _allDoctors
                .Any(doctor => doctor._specialty.Equals(this._specialty)
                    && doctor.Duties.Any(duty => duty == date));
        }
    }
}
