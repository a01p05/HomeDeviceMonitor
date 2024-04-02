using HomeDeviceMonitor.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeDeviceMonitor.Domain.Entities
{
    public class Building: AuditableEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Type { get; set; }
        public Address Address { get; set; }
        public ICollection<Device> Devices { get; set; }

    }
}
