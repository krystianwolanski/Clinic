using Clinic.Domain.Enums;
using Clinic.Domain.ValueObjects;

namespace Clinic.Domain.Entities
{
    public class Nurse : Employee
    {
        public Nurse(
            string email,
            string password,
            Role role,
            Pesel pesel,
            string firstName,
            string lastName) : base(email, password, role, pesel, firstName, lastName)
        {
        }
    }
}
