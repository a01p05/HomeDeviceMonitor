using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeDeviceMonitor.Domain.Common;

namespace HomeDeviceMonitor.Domain.ValueObject
{
    public class GeoCoordinate: ValueObjects
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public override string ToString()
        {
            return $"{Latitude:F},{Longitude:F}";
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Latitude;
            yield return Longitude;
        }
    }
}
