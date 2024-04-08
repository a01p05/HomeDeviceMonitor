using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeDeviceMonitor.Persistance
{
    internal class HDMonitorDbContextFactory : DesignTimeDbContextFactoryBase<HDMonitorDbContext>
    {
        protected override HDMonitorDbContext CreateNewInstance(DbContextOptions<HDMonitorDbContext> options)
        {
            return new HDMonitorDbContext(options);
        }
    }
}
