using Clinic.Domain.ValueObjects;

namespace Clinic.Domain.Entities
{
    public class Nurse : Employee
    {
        public Nurse(Pesel pesel, string firstName, string lastName) : base(pesel, firstName, lastName)
        {
        }
    }
}
