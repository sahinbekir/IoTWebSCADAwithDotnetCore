using System.ComponentModel.DataAnnotations;

namespace IoTWebSCADA_convert_Python_into_DotnetCore.Models
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        public string? ProjectName { get; set; }
        public int UserId { get; set; }
        public int MasterDeviceId { get; set; }
        public int SlaveDeviceId { get; set; }

    }
}
