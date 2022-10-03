using System.ComponentModel.DataAnnotations;

namespace IoTWebSCADA_convert_Python_into_DotnetCore.Models
{
    public class DeviceAlertTelemetry
    {
        [Key]
        public int AlertId { get; set; }
        public string? Message { get; set; }
        public int DeviceTelemetryId { get; set; }
    }
}
