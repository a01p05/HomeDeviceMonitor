using AutoMapper;
using HomeDeviceMonitor.Application.Common.Interfaces;
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
    public class CreateBuildingCommandHandler : IRequestHandler<CreateBuildingCommand, int>
    {
        private readonly IHDMonitorDbContext _context;
        private readonly IMapper _mapper;

        public CreateBuildingCommandHandler(IHDMonitorDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateBuildingCommand request, CancellationToken cancellationToken)
        {
            Building building = _mapper.Map<Building>(request);
           
            _context.Buildings.Add(building);

            await _context.SaveChangesAsync(cancellationToken);
            
            return building.Id;
        }
    }
}
