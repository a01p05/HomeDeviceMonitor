using HomeDeviceMonitor.Domain.Common;
using HomeDeviceMonitor.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeDeviceMonitor.Domain.Entities
{
    public class Address: AuditableEntity
    {
        public string Street { get; set; }
        public string No { get; set; }
        public string City { get; set; }
        public string Code { get; set; }
        public string Country { get; set; }
        public GeoCoordinate? Location { get; set; }
        public int BuildingId { get; set; }
        public Building Building { get; set; }
    }
}
