using HomeDeviceMonitor.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeDeviceMonitor.Application.Entities.Buildings.Commands.Delete
{
    public class DeleteBuildingCommandHandler : IRequestHandler<DeleteBuildingCommand>
    //public class DeleteBuildingCommandHandler : IRequestHandler<DeleteBuildingCommand, Unit>
    {
        private readonly IHDMonitorDbContext _context;

        public DeleteBuildingCommandHandler(IHDMonitorDbContext context)
        {
            _context = context;
        }

        public async Task Handle(DeleteBuildingCommand request, CancellationToken cancellationToken)
        //public async Task<Unit> Handle(DeleteBuildingCommand request, CancellationToken cancellationToken)
        {
            var building = await _context.Buildings.Where(p => p.Id == request.BuildingId).FirstOrDefaultAsync(cancellationToken);
            _context.Buildings.Remove(building);
            await _context.SaveChangesAsync(cancellationToken);
            //return Unit.Value;
        }
    }
}
