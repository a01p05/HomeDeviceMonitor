using Microsoft.EntityFrameworkCore;
using HomeDeviceMonitor.Application.Common.Interfaces;
using HomeDeviceMonitor.Domain.Common;
using HomeDeviceMonitor.Domain.Entities;
using HomeDeviceMonitor.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace HomeDeviceMonitor.Persistance
{
    public class HDMonitorDbContext : DbContext, IHDMonitorDbContext
    {
        private readonly IDateTime _dateTime;
        public HDMonitorDbContext(DbContextOptions<HDMonitorDbContext> options) : base(options)
        { 
        }
        public HDMonitorDbContext(DbContextOptions<HDMonitorDbContext> options, IDateTime dateTime) : base(options)
        {
            _dateTime = dateTime;
        }

        public DbSet<Building> Buildings { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<MeasurementConfiguration> Measurements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.SeedData();

            //base.OnModelCreating(modelBuilder);
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entryBase in ChangeTracker.Entries<AuditableEntityBase>())
            {
                var entry = entryBase.Entity as AuditableEntity;
                switch (entryBase.State)
                {
                    case EntityState.Added:
                        entryBase.Entity.CreatedBy = string.Empty;
                        entryBase.Entity.Created = _dateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.ModifiedBy = string.Empty;
                        entry.Modified = _dateTime.Now;
                        break;
                    case EntityState.Deleted:
                        entry.ModifiedBy = string.Empty;
                        entry.Modified = _dateTime.Now;
                        entry.InactivatedBy = string.Empty;
                        entry.Inactivated = _dateTime.Now;
                        entry.StatusId = 0;
                        entryBase.State = EntityState.Modified;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
