﻿using Microsoft.EntityFrameworkCore;
using PhotoTrip.Core.Domain;
using PhotoTrip.Core.Domain.Interfaces;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PhotoTrip.Infrastructure.Database
{
    public class PhotoTripContext : DbContext
    {
        public string UserEmail { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Point> Points { get; set; }
        public DbSet<Event> Events { get; set; }

        public PhotoTripContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder){ }

        public override int SaveChanges()
        {
            UpdateAuditEntities();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            UpdateAuditEntities();
            return base.SaveChangesAsync(cancellationToken);
        }


        private void UpdateAuditEntities()
        {
            var modifiedEntries = ChangeTracker.Entries()
                .Where(x => x.Entity is IAuditableEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));

            var userid = Users.Where(x => x.Email == UserEmail).Select(x=>x.Id).FirstOrDefault();

            foreach (var entry in modifiedEntries)
            {
                var entity = (IAuditableEntity)entry.Entity;
                DateTime now = DateTime.UtcNow;
                if (entry.State == EntityState.Added)
                {
                    entity.CreatedDate = now;
                    entity.CreatedBy = userid;
                }
                else
                {
                    base.Entry(entity).Property(x => x.CreatedDate).IsModified = false;
                    base.Entry(entity).Property(x => x.CreatedBy).IsModified = false;
                }

                entity.UpdatedDate = now;
                entity.UpdatedBy = userid;
            }
        }

    }
}
