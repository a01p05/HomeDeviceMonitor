using HomeDeviceMonitor.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeDeviceMonitor.Application.Entities.Buildings.Queries.GetCollection
{
    public class BuildingsVm
    {
        ICollection<BuildingDto> Buildings { get; set; }

    }
}
