using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using HiringSonda.Domain.UserAggregate;
using HiringSonda.Infra.Data;

namespace HiringSonda.Infra.Repository
{
    public class UserRepository : BaseRepository<ContextDatabase, UserDomain>, IUserRepository
    {
        protected ContextDatabase _context;

        public UserRepository(ContextDatabase context) : base(context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        public async Task<UserDomain> GetAddressById(int id)
        {
            var address = await _context
                                .Users
                                .AsNoTracking()
                                .Include(e => e.AddressUser)
                                .FirstOrDefaultAsync(p => p.Id == id);

            return address;
        }
    }
}
