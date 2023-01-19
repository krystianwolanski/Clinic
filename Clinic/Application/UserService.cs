using Clinic.Application.Exceptions;
using Clinic.Domain.Entities;
using Clinic.Domain.Repositories;

namespace Clinic.Application
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Add(User dto)
        {
            var user = _userRepository.Get(dto.Login);

            if (user != null)
            {
                throw new UserAlreadyExistsException(dto.Login);
            }

            _userRepository.Add(dto);
        }

        public void Add(Employee dto)
        {
            var user = _userRepository.Get(dto.Login);

            if (user != null)
            {
                throw new UserAlreadyExistsException(dto.Login);
            }

            var exists = _userRepository.ExistsByPesel(dto.Pesel);

            if (exists)
            {
                throw new UserAlreadyExistsException(dto.Login);
            }

            _userRepository.Add(dto);
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

        public T? Get<T>(string login) where T : User
        {
            return _userRepository.Get(login) as T;
        }

        public IEnumerable<T> GetAll<T>() where T : User
        {
            return _userRepository.GetAll<T>();
        }

        public User Login(string login, string password)
        {
            var user = _userRepository.Get(login);

            if (user is null)
            {
                throw new UserNotFoundException(login);
            }

            if (user.Password != password)
            {
                throw new IncorrectPasswordException();
            }

            return user;
        }

        public void Remove(string login)
        {
            var user = _userRepository.Get(login);

            if (user is null)
            {
                throw new UserNotFoundException(login);
            }

            _userRepository.Remove(user);
        }
    }
}