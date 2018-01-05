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
    public class PointRepository : IPointRepository
    {

        private readonly PhotoTripContext _context;

        public PointRepository(PhotoTripContext context)
        {
            _context = context;
        }

        public async Task<Point> Get(int id)
        {
            return await _context.Points.Include("Events").SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Point>> GetList()
        {
            return await _context.Points.Include("Events").ToListAsync();
        }


        public async Task<Point> Post(Point entity)
        {
            _context.Points.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Point> Put(Point entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }

        public async void Delete(int id)
        {
            var result = await Get(id);
            if (result == null)
            {
                return;
            }
            _context.Points.Remove(result);
            _context.SaveChanges();
        }
    }
}
