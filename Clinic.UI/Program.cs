using Clinic.Application;
using Clinic.Domain.Entities;

namespace Clinic.UI
{
    public static class Program
    {
        private static void Main()
        {
            var userService = new UserService(new UserRepository());
            userService.Add(new Nurse("sd", "", "98042308336", "", ""));

            userService.AddRange(new List<Nurse>());
            var doctors = userService.GetAll<Doctor>();
            userService.Add(new Doctor("sd3", "", doctors, "02271409862", "", "", ""));

            var nurses = userService.GetAll<Nurse>();
        }
    }
}