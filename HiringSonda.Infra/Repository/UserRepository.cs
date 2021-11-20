using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using HiringSonda.Domain.Interfaces;
using HiringSonda.Domain.Models;

namespace HiringSonda.Infra.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly Context.Context _context;

        public UserRepository(Context.Context context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        public async Task<User> GetAddressById(Guid id)
        {
            var address = await _context
                                .Users
                                .AsNoTracking()
                                .Include(e => e.addressUser)
                                .FirstOrDefaultAsync(p => p.Id == id);

            return address;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var users =  await _context
                            .Users
                            .AsNoTracking()
                            .ToListAsync();

            return users;
        }

        public async Task<User> GetUser(Guid id)
        {
            var user = await _context
                                .Users
                                .AsNoTracking()
                                .FirstOrDefaultAsync(p => p.Id == id);
            return user;
        }

        public async Task RegisterAddress(User user)
        {
            await _context.Users.AddAsync(user);
            _context.SaveChanges();
        }
    }
}
