using HomeDeviceMonitor.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeDeviceMonitor.Domain.Entities
{
    public class MeasurementConfiguration: AuditableEntity
    {
        public int DeviceId { get; set; }
        public Device Device { get; set; }
        public string MeasurementType { get; set; }
        public string MeasurementUnit { get; set; }
        public int Frequency { get; set; }
        public string ValidRange { get; set; }
        public string Thresholds { get; set; }
    }
}
