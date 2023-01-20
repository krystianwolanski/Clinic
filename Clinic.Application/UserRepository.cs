using Clinic.Domain.Entities;
using Clinic.Domain.Repositories;

namespace Clinic.Application
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _users = new();

        public void Add(User user)
        {
            _users.Add(user);
        }

        public void AddRange(IEnumerable<User> users)
        {
            _users.AddRange(users);
        }

        public bool ExistsByPesel(string pesel)
        {
            return _users.Exists(u => (u as Employee)?.Pesel == pesel);
        }

        public User? Get(string login)
        {
            return _users.FirstOrDefault(u => u.Login == login);
        }

        public IEnumerable<User> GetAll()
        {
            return _users;
        }

        public IEnumerable<T> GetAll<T>() where T : User
        {
            return _users.Where(u => u is T).Cast<T>();
        }

        public void Remove(User user)
        {
            _users.Remove(user);
        }
    }
}
