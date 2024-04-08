using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeDeviceMonitor.Application.Entities.Buildings.Queries.GetDetail
{
    public class GetBuildingDetailQuery : IRequest<BuildingDetailVm>
    {
        public int BuildingId { get; set; }
    }
}
