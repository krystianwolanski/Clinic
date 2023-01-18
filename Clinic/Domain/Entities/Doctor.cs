﻿using Clinic.Domain.Enums;
using Clinic.Domain.Exceptions;
using Clinic.Domain.ValueObjects;

namespace Clinic.Domain.Entities
{
    public class Doctor : Employee
    {
        private readonly IEnumerable<Doctor> _allDoctors;

        public Doctor(
            string login,
            string password,
            IEnumerable<Doctor> allDoctors,
            Pesel pesel,
            string firstName,
            string lastName,
            string specialty) : base(login, password, Role.Doctor, pesel, firstName, lastName)
        {
            _allDoctors = allDoctors;
            Specialty = specialty;
        }

        public string Specialty { get; set; }

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
                .Any(doctor => doctor.Specialty.Equals(this.Specialty)
                    && doctor.Duties.Any(duty => duty == date));
        }
    }
}
