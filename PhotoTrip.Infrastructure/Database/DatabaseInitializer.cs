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
            if (!_context.Events.Any())
            {
                Event @event = new Event()
                {
                    Name = "testowy event",
                    PhotoName = Guid.NewGuid().ToString(),
                    User = _context.Users.FirstOrDefault()
                };
                _context.Events.Add(@event);
                await _context.SaveChangesAsync();
            }
            if (!_context.Points.Any())
            {
                Point point = new Point()
                {
                    Latitude = 123123,
                    Longitude = 1312312,
                    Name = "Punkt",
                    User = _context.Users.FirstOrDefault(),
                    Events = _context.Events.ToList()
                };

                _context.Points.Add(point);
                await _context.SaveChangesAsync();
            }
        }
    }
}
