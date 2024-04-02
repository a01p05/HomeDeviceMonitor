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
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey("Id");
            builder.Property(p => p.Street).HasMaxLength(255);
            builder.Property(p => p.No).HasMaxLength(10);
            builder.Property(p => p.City).HasMaxLength(255);
            builder.Property(p => p.Country).HasMaxLength(255);
            builder.Property(p => p.Code).HasMaxLength(6);

            builder.OwnsOne(p => p.Location).Property(p => p.Latitude).HasColumnName("Latitude");
            builder.OwnsOne(p => p.Location).Property(p => p.Longitude).HasColumnName("Longitude");
        }
    }
}
