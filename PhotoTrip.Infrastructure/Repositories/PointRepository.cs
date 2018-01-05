﻿using PhotoTrip.Core.Repositories;
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

        public Point Get(int id)
        {
            return _context.Points.Include("Events").SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<Point> GetList()
        {
            return _context.Points.Include("Events").ToList();
        }


        public Point Post(Point entity)
        {
            _context.Points.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public Point Put(Point entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
            return entity;
        }

        public void Delete(int id)
        {
            var result = Get(id);
            if (result == null)
            {
                return;
            }
            _context.Points.Remove(result);
            _context.SaveChanges();
        }
    }
}
