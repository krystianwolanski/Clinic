using Clinic.Domain.Entities;

namespace Clinic.Application
{
    public interface IUserRepository
    {
        void Add(User user);

        void AddRange(IEnumerable<User> users);

        bool ExistsByPesel(string pesel);

        User? Get(string pesel);

        IEnumerable<User> GetAll();

        void Remove(User user);
    }

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

        public User? Get(string email)
        {
            return _users.FirstOrDefault(u => u.Email == email);
        }

        public IEnumerable<User> GetAll()
        {
            return _users;
        }

        public void Remove(User user)
        {
            _users.Remove(user);
        }
    }
}
