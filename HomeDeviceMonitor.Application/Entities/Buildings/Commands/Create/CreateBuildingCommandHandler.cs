using HomeDeviceMonitor.Application.Common.Interfaces;
using HomeDeviceMonitor.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeDeviceMonitor.Application.Entities.Buildings.Commands.Create
{
    public class CreateBuildingCommandHandler : IRequestHandler<CreateBuildingCommand, int>
    {
        private readonly IHDMonitorDbContext _context;

        public CreateBuildingCommandHandler(IHDMonitorDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateBuildingCommand request, CancellationToken cancellationToken)
        {
            Building building = new() 
            {
                Name = request.Name,
            };
            _context.Buildings.Add(building);

            await _context.SaveChangesAsync(cancellationToken);
            
            return building.Id;
        }
    }
}
