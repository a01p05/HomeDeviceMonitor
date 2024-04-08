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
    public class DeviceDto : IMapFrom<Device>
    {
        public int DeviceId { get; set; }
        public string DeviceName { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Device, DeviceDto>()
                .ForMember(d => d.DeviceId, map => map.MapFrom(src => src.Id));
        }
    }
}
