using Clinic.Domain.Entities;

namespace Clinic.Domain.Repositories
{
    public interface IUserRepository
    {
        void Add(User user);

        void AddRange(IEnumerable<User> users);

        bool ExistsByPesel(string pesel);

        User? Get(string login);

        IEnumerable<User> GetAll();

        IEnumerable<T> GetAll<T>() where T : User;

        void Remove(User user);
    }
}
