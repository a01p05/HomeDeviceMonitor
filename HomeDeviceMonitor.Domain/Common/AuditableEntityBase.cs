using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeDeviceMonitor.Domain.Common
{
    public abstract class AuditableEntityBase
    {
        public int Id { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime Created { get; set; }
    }
}
