using Clinic.Domain;

namespace Clinic.Application
{
    public interface IEmployeeRepository<TEntity> where TEntity : Employee
    {
        void Add(TEntity employee);

        void AddRange(IEnumerable<TEntity> employees);

        TEntity? Get(string pesel);

        IEnumerable<TEntity> GetAll();

        void Remove(TEntity employee);
    }

    public class EmployeeRepository<TEntity> : IEmployeeRepository<TEntity> where TEntity : Employee
    {
        private readonly List<TEntity> _data = new();

        public void Add(TEntity employee)
        {
            _data.Add(employee);
        }

        public void AddRange(IEnumerable<TEntity> employees)
        {
            _data.AddRange(employees);
        }

        public TEntity? Get(string pesel)
        {
            return _data.FirstOrDefault(d => d.Pesel == pesel);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _data;
        }

        public void Remove(TEntity employee)
        {
            _data.Remove(employee);
        }
    }
}
