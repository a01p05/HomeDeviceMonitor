using HomeDeviceMonitor.Application.Entities.Buildings.Queries.GetDetail;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeDeviceMonitor.Application.Entities.Buildings.Commands.Create
{
    public class CreateBuildingCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Type { get; set; }
        //public AddressDto Address { get; set; }

    }
}
