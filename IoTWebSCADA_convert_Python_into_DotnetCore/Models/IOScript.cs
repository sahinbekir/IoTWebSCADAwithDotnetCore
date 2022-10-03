using System.ComponentModel.DataAnnotations;

namespace IoTWebSCADA_convert_Python_into_DotnetCore.Models
{
    public class IOScript
    {
        [Key]
        public int IOScriptId { get; set; }
        public string? MasterDeviceUID { get; set; }
        public string? SlaveDeviceUID { get; set; }
        public int MasterSlaveId { get; set; }
        public int SlaveSlaveId { get; set; }
        public string? MasterIOName { get; set; }
        public string? SlaveIOName { get; set; }
        public int LastValue { get; set; }
        public string? Description { get; set; }
    }
}
