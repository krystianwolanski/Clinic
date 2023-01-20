using Clinic.Domain.Enums;
using Clinic.Domain.Repositories;
using Clinic.Domain.ValueObjects;

namespace Clinic.Domain.Entities
{
    public class Nurse : Employee
    {
        public Nurse(
            Login login,
            Password password,
            Pesel pesel,
            FirstName firstName,
            LastName lastName,
            IUserRepository userRepository) : base(login, password, Role.Nurse, pesel, firstName, lastName, userRepository)
        {
        }
    }
}
