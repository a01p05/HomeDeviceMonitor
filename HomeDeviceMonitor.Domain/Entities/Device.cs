using HomeDeviceMonitor.Domain.Common;
using HomeDeviceMonitor.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeDeviceMonitor.Domain.Entities
{
    public class Device: AuditableEntity
    {
        public string DeviceName { get; set; }
        public string? DeviceDescription { get; set; }
        public string DeviceType { get; set; }
        public Url? Url { get; set; }
        public int? Frequency { get; set; }
        public ICollection<Device> Devices { get; set; }
        public int? ParentDeviceId { get; set; }
        public Device ParentDevice { get; set; }
        public ICollection<MeasurementConfiguration> Measurements { get; set; }
        public int? BuildingId { get; set; }
        public Building Building { get; set; }
    }
}
