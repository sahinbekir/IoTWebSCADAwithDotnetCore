// <auto-generated />
using System;
using IoTWebSCADA_convert_Python_into_DotnetCore.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace IoTWebSCADA_convert_Python_into_DotnetCore.Database.Migrations
{
    [DbContext(typeof(IoTWS_DbContext))]
    partial class IoTWS_DbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("IoTWebSCADA_convert_Python_into_DotnetCore.Models.Device", b =>
                {
                    b.Property<int>("DeviceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DeviceId"), 1L, 1);

                    b.Property<DateTime>("DeviceCreateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("DeviceIsActive")
                        .HasColumnType("bit");

                    b.Property<string>("DeviceName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeviceUID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DeviceUpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("DeviceId");

                    b.ToTable("Devices");
                });

            modelBuilder.Entity("IoTWebSCADA_convert_Python_into_DotnetCore.Models.DeviceAlertTelemetry", b =>
                {
                    b.Property<int>("AlertId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AlertId"), 1L, 1);

                    b.Property<int>("DeviceTelemetryId")
                        .HasColumnType("int");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AlertId");

                    b.ToTable("DeviceAlertTelemetries");
                });

            modelBuilder.Entity("IoTWebSCADA_convert_Python_into_DotnetCore.Models.DeviceTelemetry", b =>
                {
                    b.Property<int>("DeviceTelemetryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DeviceTelemetryId"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeviceUID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IOName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MessageId")
                        .HasColumnType("int");

                    b.Property<int>("SlaveId")
                        .HasColumnType("int");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("DeviceTelemetryId");

                    b.ToTable("DeviceTelemetries");
                });

            modelBuilder.Entity("IoTWebSCADA_convert_Python_into_DotnetCore.Models.IOScript", b =>
                {
                    b.Property<int>("IOScriptId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IOScriptId"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LastValue")
                        .HasColumnType("int");

                    b.Property<string>("MasterDeviceUID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MasterIOName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MasterSlaveId")
                        .HasColumnType("int");

                    b.Property<string>("SlaveDeviceUID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SlaveIOName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SlaveSlaveId")
                        .HasColumnType("int");

                    b.HasKey("IOScriptId");

                    b.ToTable("IOScripts");
                });

            modelBuilder.Entity("IoTWebSCADA_convert_Python_into_DotnetCore.Models.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProjectId"), 1L, 1);

                    b.Property<int>("MasterDeviceId")
                        .HasColumnType("int");

                    b.Property<string>("ProjectName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SlaveDeviceId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ProjectId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("IoTWebSCADA_convert_Python_into_DotnetCore.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("UserEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserFirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserLastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserPassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserType")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
