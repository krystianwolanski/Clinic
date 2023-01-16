using Autofac;
using Clinic.Application;
using Clinic.Application.Doctors;
using Clinic.Application.Nurses;
using Clinic.Domain.Entities;

public class Program
{
    private static IContainer Container { get; set; }

    private static void Main(string[] args)
    {
        var doctorRepository = new EmployeeRepository<Doctor>();
        var nurseRepository = new EmployeeRepository<Nurse>();
        var employeeReadService = new EmployeeReadService(doctorRepository, nurseRepository);
        var doctorService = new DoctorService(employeeReadService, doctorRepository);
    }

    private void Test()
    {
        var builder = new ContainerBuilder();
        builder.RegisterType<EmployeeRepository<Doctor>>().As<IEmployeeRepository<Doctor>>().SingleInstance();
        builder.RegisterType<EmployeeRepository<Nurse>>().As<IEmployeeRepository<Nurse>>().SingleInstance();
        builder.RegisterType<EmployeeReadService>().As<IEmployeeReadService>().SingleInstance();
        builder.RegisterType<DoctorService>().SingleInstance();
        builder.RegisterType<NurseService>().SingleInstance();

        Container = builder.Build();
        using (var scope = Container.BeginLifetimeScope())
        {
        }
    }
}
