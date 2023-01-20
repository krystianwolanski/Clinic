using Clinic.Domain.Enums;
using Clinic.Domain.Exceptions;
using Clinic.Domain.Repositories;
using Clinic.Domain.ValueObjects;

namespace Clinic.Domain.Entities
{
    public abstract class Employee : User
    {
        protected readonly IUserRepository UserRepository;
        private readonly List<DateOnly> _duties = new();
        private readonly int _maxDutiesCount = 10;
        private Pesel _pesel;

        protected Employee(
            Login login,
            Password password,
            Role role,
            Pesel pesel,
            FirstName firstName,
            LastName lastName,
            IUserRepository userRepository) : base(login, password, role)
        {
            _pesel = pesel;
            FirstName = firstName;
            LastName = lastName;
            UserRepository = userRepository;
        }

        public IEnumerable<DateOnly> Duties => _duties;
        public FirstName FirstName { get; set; }
        public LastName LastName { get; set; }

        public Pesel Pesel
        {
            get => _pesel;
            set
            {
                var userExists = UserRepository.ExistsByPesel(value);

                if (userExists)
                {
                    throw new EmployeeAlreadyExistsException(value);
                }

                _pesel = value;
            }
        }

        public virtual void AddDuty(DateOnly duty)
        {
            if (HasDutyOnThisDay(duty))
            {
                throw new DutyOnThisDayException(Pesel);
            }

            if (HasMaxDutiesPerMonth(duty))
            {
                throw new MaxDutiesPerMonthException(Pesel, _maxDutiesCount);
            }

            if (IsItDutyTheDayAfterAnother(duty))
            {
                throw new DutyTheDayAfterAnotherException(Pesel);
            }

            _duties.Add(duty);
        }

        public void RemoveDuty(DateOnly duty)
        {
            _duties.Remove(duty);
        }

        private bool HasDutyOnThisDay(DateOnly date)
        {
            return _duties.Any(d => d.Equals(date));
        }

        private bool HasMaxDutiesPerMonth(DateOnly duty)
        {
            return _duties
                .Where(d => d.Year == duty.Year && d.Month == duty.Month)
                .Count() >= _maxDutiesCount;
        }

        private bool IsItDutyTheDayAfterAnother(DateOnly duty)
        {
            return _duties.Any(d => d.AddDays(1).Equals(duty));
        }
    }
}
