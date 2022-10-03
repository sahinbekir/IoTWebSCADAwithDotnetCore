using System.ComponentModel.DataAnnotations;

namespace IoTWebSCADA_convert_Python_into_DotnetCore.Models
{
    public class DeviceTelemetry
    {
        [Key]
        public int DeviceTelemetryId { get; set; }
        public string? DeviceUID { get; set; }
        public int SlaveId { get; set; }
        public int MessageId { get; set; }
        public string? IOName { get; set; }
        public int Value { get; set; }
        public DateTime Date { get; set; }
    }
}
