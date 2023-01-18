using Clinic.Domain.Enums;
using Clinic.Domain.ValueObjects;

namespace Clinic.Domain.Entities
{
    public class Nurse : Employee
    {
        public Nurse(
            string login,
            string password,
            Pesel pesel,
            string firstName,
            string lastName) : base(login, password, Role.Nurse, pesel, firstName, lastName)
        {
        }
    }
}
