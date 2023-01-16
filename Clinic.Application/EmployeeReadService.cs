using Clinic.Domain;
using Clinic.Domain.Entities;

namespace Clinic.Application
{
    public interface IEmployeeReadService
    {
        bool ExistsByPesel(string pesel);
    }

    public class EmployeeReadService : IEmployeeReadService
    {
        private readonly IEmployeeRepository<Doctor> _doctorRepository;
        private readonly IEmployeeRepository<Nurse> _nurseRepository;

        public EmployeeReadService(
            IEmployeeRepository<Doctor> doctorRepository,
            IEmployeeRepository<Nurse> nurseRepository)
        {
            _doctorRepository = doctorRepository;
            _nurseRepository = nurseRepository;
        }

        public bool ExistsByPesel(string pesel)
        {
            var employees = GetEmployees();

            return employees.Any(e => e.Pesel == pesel);
        }

        private IEnumerable<Employee> GetEmployees()
        {
            var employees = new List<Employee>();
            employees.AddRange(_doctorRepository.GetAll());
            employees.AddRange(_nurseRepository.GetAll());

            return employees;
        }
    }
}
