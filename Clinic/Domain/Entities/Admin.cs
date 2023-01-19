using Clinic.Domain.Enums;
using Clinic.Domain.ValueObjects;

namespace Clinic.Domain.Entities
{
    public class Admin : User
    {
        public Admin(Login login, Password password) : base(login, password, Role.Admin)
        {
        }
    }
}
