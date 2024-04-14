using HiringSonda.Application.Person.Models.Response;
using HiringSonda.Domain.UserAggregate;

namespace HiringSonda.Application.Person.Services
{
    public class PersonService(IUserRepository userRepository) : IPersonService
    {
        private readonly IUserRepository _userRepository = userRepository;

        public async Task<UserDomain> GetUser(int id)
        {
            var user = await _userRepository.GetByIdAsync(id, false);
            return user;
        }

        public async Task<IEnumerable<UserResponse>> GetAllUsers()
        {
            var users = await _userRepository.GetAllAsync();

            var result = users.Select(user => (UserResponse)user).ToList();

            return result;
        }

        public async Task RegisterAddress(UserDomain user)
        {
            await _userRepository.InsertOrUpdateAsync(user);
        }

        public async Task<UserDomain> GetAddressById(int id)
        {
            var addresses = await _userRepository.GetAddressById(id);
            return addresses;
        }

    }
}
