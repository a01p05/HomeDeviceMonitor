using AutoMapper;
using HomeDeviceMonitor.Application.Common.Interfaces;
using HomeDeviceMonitor.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeDeviceMonitor.Application.Entities.Buildings.Queries.GetDetail
{
    public class GetBuildingDetailQueryHandler : IRequestHandler<GetBuildingDetailQuery, BuildingDetailVm>
    {
        private readonly IHDMonitorDbContext _context;
        private readonly IMapper _mapper;

        public GetBuildingDetailQueryHandler(IHDMonitorDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BuildingDetailVm> Handle(GetBuildingDetailQuery request, CancellationToken cancellationToken)
        {
            var building = await _context.Buildings.Include(p => p.Address).Include(p => p.Devices).Where(p => p.Id == request.BuildingId).FirstOrDefaultAsync(cancellationToken);
            var buildingVm = _mapper.Map<BuildingDetailVm>(building);
           
            return buildingVm;
        }

        private class xxxResolver : IValueResolver<Building, object, string>
        {
            public string Resolve(Building source, object destination, string destMember, ResolutionContext context)
            {
                throw new NotImplementedException();
            }
        }
    }
}
