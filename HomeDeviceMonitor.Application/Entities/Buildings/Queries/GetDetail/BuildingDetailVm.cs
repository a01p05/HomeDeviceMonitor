using AutoMapper;
using HomeDeviceMonitor.Application.Common.Mappings;
using HomeDeviceMonitor.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeDeviceMonitor.Application.Entities.Buildings.Queries.GetDetail
{
    public class BuildingDetailVm : IMapFrom<Building>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Type { get; set; }
        public AddressDto Address { get; set; }
        public ICollection<DeviceDto> Devices { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Building, BuildingDetailVm>();
        }
    }
}
