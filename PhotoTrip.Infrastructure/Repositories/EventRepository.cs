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

        public async Task Delete(int id)
        {
            var result = await Get(id);
            if (result == null)
            {
                return;
            }
            _context.Events.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task<Event> Get(int id)
        {
            return await _context.Events.Include("Photo").SingleAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Event>> GetList()
        {
            return await _context.Events.Include("Photo").ToListAsync();
        }

        public async Task<Event> Post(Event entity)
        {
            entity.Point = await _context.Points.FirstOrDefaultAsync(x => x.Id == entity.Point.Id);
            await _context.Events.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Event> Put(Event entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }

    }
}
