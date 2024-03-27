using Microsoft.EntityFrameworkCore;
using HomeDeviceMonitor.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeDeviceMonitor.Domain.Common;

namespace HomeDeviceMonitor.Persistance
{
    public class HomeDeviceMonitorDbContext : DbContext
    {
        public HomeDeviceMonitorDbContext(DbContextOptions<HomeDeviceMonitorDbContext> options): base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
                        entryBase.Entity.Created = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.ModifiedBy = string.Empty;
                        entry.Modified = DateTime.Now;
                        break;
                    case EntityState.Deleted:
                        entry.ModifiedBy = string.Empty;
                        entry.Modified = DateTime.Now;
                        entry.InactivatedBy = string.Empty;
                        entry.Inactivated = DateTime.Now;
                        entry.StatusId = 0;
                        entryBase.State = EntityState.Modified;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
