using HiringSonda.Application.Person.Models.Response;
using HiringSonda.Domain.UserAggregate;
using Microsoft.AspNetCore.Mvc;

namespace HiringSonda.Application.Person.Services
{
    public interface IPersonService
    {
        public Task<IEnumerable<UserResponse>> GetAllUsers();
        public Task<UserDomain> GetUser(int id);
        public Task RegisterAddress(UserDomain user);
        public Task<UserDomain> GetAddressById(int id);

    }
}
