using Clinic.Application.Nurses.Models;
using Clinic.Domain.Entities;
using Clinic.Domain.Exceptions;

namespace Clinic.Application.Nurses
{
    public class NurseService
    {
        private readonly IEmployeeReadService _employeeReadService;
        private readonly IEmployeeRepository<Nurse> _nurseRepository;

        public NurseService(IEmployeeRepository<Nurse> nurseRepository, IEmployeeReadService employeeReadService)
        {
            _nurseRepository = nurseRepository;
            _employeeReadService = employeeReadService;
        }

        public void Add(CreateNurseDto dto)
        {
            var employeeExists = _employeeReadService.ExistsByPesel(dto.Pesel);

            if (employeeExists)
            {
                throw new EmployeeAlreadyExistsException(dto.Pesel);
            }

            _nurseRepository.Add(new Nurse(dto.Pesel, dto.FirstName, dto.LastName));
        }

        public void AddRange(IEnumerable<CreateNurseDto> dtos)
        {
            foreach (var dto in dtos)
            {
                Add(dto);
            }
        }

        public IEnumerable<Nurse> GetAll()
        {
            return _nurseRepository.GetAll();
        }

        public void Remove(string pesel)
        {
            var nurse = _nurseRepository.Get(pesel);

            if (nurse is null)
            {
                throw new EmployeeNotFoundException(pesel);
            }

            _nurseRepository.Remove(nurse);
        }
    }
}
