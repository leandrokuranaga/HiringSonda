using HiringSonda.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HiringSonda.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUser(Guid id);
        Task RegisterAddress(User user); 
        Task<User> GetAddressById(Guid id);

    }
}
