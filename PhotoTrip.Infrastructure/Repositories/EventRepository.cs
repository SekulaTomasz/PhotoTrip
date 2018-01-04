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
    public class EventRepository : IEventRepository
    {
        private readonly PhotoTripContext _context;

        public EventRepository(PhotoTripContext context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            var result = Get(id);
            if (result == null)
            {
                return;
            }
            _context.Events.Remove(result);
            _context.SaveChanges();
        }

        public Event Get(int id)
        {
            return _context.Events.Single(x => x.Id == id);
        }

        public IEnumerable<Event> GetList()
        {
            return _context.Events.ToList();
        }

        public void Post(Event entity)
        {
            entity.Point = _context.Points.FirstOrDefault(x => x.Id == entity.Point.Id);
            _context.Events.Add(entity);
            _context.SaveChanges();
        }

        public void Put(Event entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
