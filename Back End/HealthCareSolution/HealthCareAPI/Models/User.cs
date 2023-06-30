using System.ComponentModel.DataAnnotations;

namespace HealthCareAPI.Models
{
    public class User
    {
        [Key]
        public string? UserId { get; set; }
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordKey { get; set; }
        public string? EmailID { get; set; }
        public string? Role { get; set; }
        public string? Status { get;set; }
    }
}
