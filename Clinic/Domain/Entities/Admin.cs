using Clinic.Domain.Enums;

namespace Clinic.Domain.Entities
{
    public class Admin : User
    {
        public Admin(string login, string password) : base(login, password, Role.Admin)
        {
        }
    }
}
