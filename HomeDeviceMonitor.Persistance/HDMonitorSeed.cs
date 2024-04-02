using HomeDeviceMonitor.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace HomeDeviceMonitor.Persistance
{
    public static class HDMonitorSeed
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Building>(p =>
            {
                p.HasData(new Building()
                {
                    Id = 1,
                    StatusId = 1,
                    Created = DateTime.Now,
                    Name = "Dom test",
                });
            });

            modelBuilder.Entity<Address>(p => {
                p.HasData(new Address()
                {
                    Id=1,
                    StatusId = 1,
                    Created = DateTime.Now,
                    BuildingId = 1,
                    Street = "Busolowa",
                    No = "81",
                    City = "Częstochowa",
                    Code = "42-280",
                    Country = "Polska"
                });
                p.OwnsOne(a => a.Location).HasData(new { AddressId =1, Latitude = 50.7776512, Longitude = 19.0383173 });
            });

            modelBuilder.Entity<Device>(p => {
                p.HasData(new Device()
                {
                    Id = 1,
                    StatusId = 1,
                    Created = DateTime.Now,
                    BuildingId = 1,
                    DeviceName = "PVmonitor",
                    DeviceType = "Real",
                    Frequency = 60
                });
                p.OwnsOne(d => d.Url).HasData(new { DeviceId = 1, Ip = "31.42.6.141", Port = "14180", Protocol = "http", Path = "public" });
            });

            modelBuilder.Entity<Device>(p => {
                p.HasData(new Device()
                {
                    Id = 2,
                    StatusId = 1,
                    Created = DateTime.Now,
                    DeviceName = "sofar1",
                    DeviceDescription = "Sofar KTL-X",
                    DeviceType = "Virtual"
                });
            });

            modelBuilder.Entity<MeasurementConfiguration>(p => {
                p.HasData(new MeasurementConfiguration()
                {
                    Id = 1,
                    StatusId = 1,
                    Created = DateTime.Now,
                    DeviceId = 2
                });
            });
        }
    }
}
