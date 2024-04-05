using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeDeviceMonitor.Application.Entities.Buildings.Commands.Delete
{
    public class DeleteBuildingCommand : IRequest
    //public class DeleteBuildingCommand : IRequest<Unit>
    {
        public int BuildingId { get; set; } 
    }
}
