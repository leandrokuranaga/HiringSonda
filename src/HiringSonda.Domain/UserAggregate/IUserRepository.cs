using HiringSonda.Infra.Repository;
using System.Threading.Tasks;

namespace HiringSonda.Domain.UserAggregate
{
    public interface IUserRepository : IBaseRepository<UserDomain>
    {
        Task<UserDomain> GetAddressById(int id);
    }
}
