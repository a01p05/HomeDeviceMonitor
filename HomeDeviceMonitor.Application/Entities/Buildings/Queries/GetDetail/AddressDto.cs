using AutoMapper;
using HomeDeviceMonitor.Application.Common.Mappings;
using HomeDeviceMonitor.Domain.Entities;
using HomeDeviceMonitor.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeDeviceMonitor.Application.Entities.Buildings.Queries.GetDetail
{
    public class AddressDto : IMapFrom<Address>
    {
        public string Street { get; set; }
        public string No { get; set; }
        public string City { get; set; }
        public string Code { get; set; }
        public string Country { get; set; }
        public GeoCoordinate? Location { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Address, AddressDto>();
        }
    }
}
