using Clinic.Application.Exceptions;
using Clinic.Domain.Entities;
using Clinic.Domain.Enums;

namespace Clinic.Application
{
    public class UserService
    {
        private readonly IUserRepository _users;

        public UserService(IUserRepository doctors)
        {
            _users = doctors;
        }

        public void Add(User dto)
        {
            var user = _users.Get(dto.Email);

            if (user != null)
            {
                throw new UserAlreadyExistsException(dto.Email);
            }

            _users.Add(dto);
        }

        public void Add(Employee dto)
        {
            var user = _users.Get(dto.Email);

            if (user != null)
            {
                throw new UserAlreadyExistsException(dto.Email);
            }

            var exists = _users.ExistsByPesel(dto.Pesel);

            if (exists)
            {
                throw new UserAlreadyExistsException(dto.Email);
            }

            _users.Add(dto);
        }

        public void AddRange(IEnumerable<User> dtos)
        {
            foreach (var dto in dtos)
            {
                Add(dto);
            }
        }

        public void AddRange(IEnumerable<Employee> dtos)
        {
            foreach (var dto in dtos)
            {
                Add(dto);
            }
        }

        public IEnumerable<User> GetAll()
        {
            return _users.GetAll();
        }

        public Role Login(string email, string password)
        {
            var user = _users.Get(email);

            if (user?.Password != password)
            {
                throw new UncorrectLoginOrPasswordException();
            }

            return user.Role;
        }

        public void Remove(string email)
        {
            var user = _users.Get(email);

            if (user is null)
            {
                throw new UserNotFoundException(email);
            }

            _users.Remove(user);
        }
    }
}