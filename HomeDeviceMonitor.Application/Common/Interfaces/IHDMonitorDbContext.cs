using HomeDeviceMonitor.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic; 
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeDeviceMonitor.Application.Common.Interfaces
{
    public interface IHDMonitorDbContext
    {
        DbSet<Building> Buildings { get; set; }
        DbSet<Address> Addresses { get; set; }
        DbSet<Device> Devices { get; set; }
        DbSet<MeasurementConfiguration> Measurements { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
