using IoTWebSCADA_convert_Python_into_DotnetCore.Models;
using Microsoft.EntityFrameworkCore;

namespace IoTWebSCADA_convert_Python_into_DotnetCore.Database
{
    public class IoTWS_DbContext:DbContext
    {
        public IoTWS_DbContext(DbContextOptions<IoTWS_DbContext>o)
            : base(o) 
        {
            
        }
        public DbSet<Device>? Devices { get; set; }
        public DbSet<DeviceAlertTelemetry>? DeviceAlertTelemetries { get; set; }
        public DbSet<DeviceTelemetry>? DeviceTelemetries { get; set; }
        public DbSet<IOScript>? IOScripts { get; set; }
        public DbSet<Project>? Projects { get; set; }
        public DbSet<User>? Users { get; set; }
    }
}
/*
 Migration:
Add-Migration DbName -o Database/Migrations
Update-Database
for remove Remove-Migration
 */