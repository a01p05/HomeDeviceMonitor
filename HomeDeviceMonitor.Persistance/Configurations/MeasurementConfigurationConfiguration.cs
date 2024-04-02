using HomeDeviceMonitor.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace HomeDeviceMonitor.Persistance.Configurations
{
    public class MeasurementConfigurationConfiguration : IEntityTypeConfiguration<MeasurementConfiguration>
    {
        public void Configure(EntityTypeBuilder<MeasurementConfiguration> builder)
        {
            builder.HasKey("Id");
        }
    }
}
