using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoTrip.Infrastructure.Database
{
    public class PhotoTripContext : DbContext
    {
        public PhotoTripContext(DbContextOptions<PhotoTripContext> conn) : base(conn)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) { }
    }
}
