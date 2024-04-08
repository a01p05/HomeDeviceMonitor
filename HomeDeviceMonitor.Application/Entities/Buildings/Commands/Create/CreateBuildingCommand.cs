using AutoMapper;
using HomeDeviceMonitor.Application.Common.Mappings;
using HomeDeviceMonitor.Application.Entities.Buildings.Queries.GetDetail;
using HomeDeviceMonitor.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeDeviceMonitor.Application.Entities.Buildings.Commands.Create
{
    public class CreateBuildingCommand : IRequest<int>, IMapFrom<Building>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Type { get; set; }
        public CreateAdressCommand Address { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateBuildingCommand, Building>();
        }
    }
}
