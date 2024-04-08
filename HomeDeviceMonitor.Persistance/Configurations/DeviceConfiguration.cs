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
    public class DeviceConfiguration : IEntityTypeConfiguration<Device>
    {
        public void Configure(EntityTypeBuilder<Device> builder)
        {
            builder.HasKey("Id");
            builder.Property(p => p.DeviceName).HasMaxLength(255).IsRequired();
            builder.Property(p => p.DeviceDescription).HasMaxLength(3000);
            builder.Property(p => p.DeviceType).HasMaxLength(255).IsRequired();

            builder.OwnsOne(p => p.Url).Property(p => p.Ip).HasColumnName("Ip").HasMaxLength(15);
            builder.OwnsOne(p => p.Url).Property(p => p.Host).HasColumnName("Host").HasMaxLength(255);
            builder.OwnsOne(p => p.Url).Property(p => p.Port).HasColumnName("Port").HasMaxLength(10).IsRequired();
            builder.OwnsOne(p => p.Url).Property(p => p.Protocol).HasColumnName("Protocol").HasMaxLength(10).IsRequired();
            builder.OwnsOne(p => p.Url).Property(p => p.Path).HasColumnName("Path").HasMaxLength(255);
            builder.OwnsOne(p => p.Url).Property(p => p.Parameter).HasColumnName("Parameter").HasMaxLength(255);
        }
    }
}
