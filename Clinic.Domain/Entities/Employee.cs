using Clinic.Domain.Exceptions;
using Clinic.Domain.ValueObjects;

namespace Clinic.Domain
{
    public abstract class Employee
    {
        private readonly List<DateOnly> _duties = new();
        private readonly int _maxDutiesCount = 10;

        protected Employee(Pesel pesel, string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            Pesel = pesel;
        }

        public IEnumerable<DateOnly> Duties => _duties;
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Pesel Pesel { get; }

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
