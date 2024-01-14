using HiringSonda.Application.Person.Models.Response;
using HiringSonda.Domain.UserAggregate;

namespace HiringSonda.Application.Person.Services
{
    public class PersonService : IPersonService
    {
        private readonly IUserRepository _userRepository;

        public PersonService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDomain> GetUser(int id)
        {
            var user = await _userRepository.GetByIdAsync(id, false);
            return user;
        }

        public async Task<IEnumerable<UserResponse>> GetAllUsers()
        {
            var users = await _userRepository.GetAllAsync();

            List<UserResponse> result = [];

            foreach (var user in users)
            {
                UserResponse userResponse = new UserResponse
                {
                    FullName = user.FullName,
                    Id = user.Id
                };

                result.Add(userResponse);
            }

            return result;
        }

        public async Task RegisterAddress(UserDomain user)
        {
            await _userRepository.RegisterAddress(user);
        }

        public async Task<UserDomain> GetAddressById(int id)
        {
            var addresses = await _userRepository.GetAddressById(id);
            return addresses;
        }

    }
}
