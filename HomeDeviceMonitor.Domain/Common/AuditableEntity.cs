using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeDeviceMonitor.Domain.Common
{
    public abstract class AuditableEntity: AuditableEntityBase
    {
        public string ModifiedBy { get; set; }
        public DateTime? Modified { get; set; }
        public string InactivatedBy { get; set; }
        public DateTime Inactivated { get; set; }
        public int StatusId { get; set; }
    }
}
