namespace IoTWebSCADA_convert_Python_into_DotnetCore.Models
{
    public class Device
    {
        public int DeviceId { get; set; }
        public int UserId { get; set; }
        public string? DeviceUID { get; set; }
        public string? DeviceName { get; set; }
        public bool DeviceIsActive { get; set; }
        public DateTime DeviceCreateTime { get; set; }
        public DateTime DeviceUpdateTime { get; set; }

    }
}
