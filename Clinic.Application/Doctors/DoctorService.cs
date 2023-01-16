using Clinic.Application.Doctors.Models;
using Clinic.Domain.Entities;
using Clinic.Domain.Exceptions;

namespace Clinic.Application.Doctors
{
    public class DoctorService
    {
        private readonly IEmployeeRepository<Doctor> _doctorRepository;
        private readonly IEmployeeReadService _employeeReadService;

        public DoctorService(IEmployeeReadService employeeReadService, IEmployeeRepository<Doctor> doctorRepository)
        {
            _employeeReadService = employeeReadService;
            _doctorRepository = doctorRepository;
        }

        public void Add(CreateDoctorDto dto)
        {
            var employeeExists = _employeeReadService.ExistsByPesel(dto.Pesel);

            if (employeeExists)
                throw new EmployeeAlreadyExistsException(dto.Pesel);

            var allDoctors = _doctorRepository.GetAll();
            _doctorRepository.Add(new Doctor(allDoctors, dto.Pesel, dto.FirstName, dto.LastName, "test"));
        }

        public void AddDuty(string pesel, DateOnly duty)
        {
            var doctor = _doctorRepository.Get(pesel);

            if (doctor is null)
                throw new EmployeeNotFoundException(pesel);

            doctor.AddDuty(duty);
        }

        public void AddRange(IEnumerable<CreateDoctorDto> dtos)
        {
            foreach (var dto in dtos)
            {
                Add(dto);
            }
        }

        public IEnumerable<Doctor> GetAll()
        {
            return _doctorRepository.GetAll();
        }

        public void Remove(string pesel)
        {
            var doctor = _doctorRepository.Get(pesel);

            if (doctor is null)
                throw new EmployeeNotFoundException(pesel);

            _doctorRepository.Remove(doctor);
        }
    }
}
