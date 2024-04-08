using AutoMapper;
using HomeDeviceMonitor.Application.Common.Mappings;
using HomeDeviceMonitor.Application.Entities.Buildings.Queries.GetDetail;
using HomeDeviceMonitor.Domain.Entities;
using HomeDeviceMonitor.Domain.ValueObject;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeDeviceMonitor.Application.Entities.Buildings.Commands.Create
{
    public class CreateAdressCommand : IRequest<int>, IMapFrom<Address>
    {
        public string Street { get; set; }
        public string No { get; set; }
        public string City { get; set; }
        public string Code { get; set; }
        public string Country { get; set; }
        public GeoCoordinate? Location { get; set; }
        //public int BuildingId { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateAdressCommand, Address>();
        }
    }
}
