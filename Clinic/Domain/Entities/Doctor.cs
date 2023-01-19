using Clinic.Domain.Enums;
using Clinic.Domain.Exceptions;
using Clinic.Domain.Repositories;
using Clinic.Domain.ValueObjects;

namespace Clinic.Domain.Entities
{
    public class Doctor : Employee
    {
        private readonly IUserRepository _userRepository;

        public Doctor(
            Login login,
            Password password,
            Pesel pesel,
            FirstName firstName,
            LastName lastName,
            Specialty specialty,
            IUserRepository userRepository) : base(login, password, Role.Doctor, pesel, firstName, lastName)
        {
            Specialty = specialty;
            _userRepository = userRepository;
        }

        public Specialty Specialty { get; set; }

        public override void AddDuty(DateOnly duty)
        {
            var allDoctors = _userRepository.GetAll<Doctor>();

            if (IsThereADoctorWithThisSpecialtyOnDuty(duty, allDoctors))
            {
                throw new DoctorWithThisSpecialtyAlreadyOnDutyException(duty);
            }

            base.AddDuty(duty);
        }

        private bool IsThereADoctorWithThisSpecialtyOnDuty(DateOnly duty, IEnumerable<Doctor> allDoctors)
        {
            return allDoctors
                .Any(doctor => doctor.Specialty.Equals(this.Specialty)
                    && doctor.Duties.Any(d => d.Equals(duty)));
        }
    }
}
