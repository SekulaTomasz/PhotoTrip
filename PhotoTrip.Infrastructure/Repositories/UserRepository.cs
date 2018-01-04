using PhotoTrip.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using PhotoTrip.Core.Domain;
using System.Threading.Tasks;
using PhotoTrip.Infrastructure.Database;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PhotoTrip.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly PhotoTripContext _context;

        public UserRepository(PhotoTripContext context)
        {
            _context = context;
        }


        public Task DeleteAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetListAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public Task PostAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public Task PutAsync(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
