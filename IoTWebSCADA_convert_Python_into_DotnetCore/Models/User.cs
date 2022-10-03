using System.ComponentModel.DataAnnotations;

namespace IoTWebSCADA_convert_Python_into_DotnetCore.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public int UserType { get; set; }
        public string? UserFirstName { get; set; }
        public string? UserLastName { get; set; }
        public string? UserPhone { get; set; }
        public string? UserEmail { get; set; }
        public string? UserName { get; set; }
        public string? UserPassword { get; set; }
    }
}
