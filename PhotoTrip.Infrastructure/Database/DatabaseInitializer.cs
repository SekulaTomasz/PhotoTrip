using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using PhotoTrip.Core.Domain;

namespace PhotoTrip.Infrastructure.Database
{

    public interface IDatabaseInitializer
    {
        Task SeedAsync();
    }

    public class DatabaseInitializer : IDatabaseInitializer
    {

        private readonly PhotoTripContext _context;

        public DatabaseInitializer(PhotoTripContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            if (!_context.Users.Any())
            {

                User user = new User()
                {
                    Email = "admin@admin.pl",
                    Password = "password",
                    Login = "admin"
                };
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
            }
            throw new NotImplementedException();
        }
    }
}
