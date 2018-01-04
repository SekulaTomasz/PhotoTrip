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

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public User Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetList()
        {
            return _context.Users.ToList();
        }

        public void Post(User entity)
        {
            throw new NotImplementedException();
        }

        public void Put(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
