using System.ComponentModel.DataAnnotations;

namespace HealthCareAPI.Models.DTO
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }

        public string? UserId { get; set; }
        public string? Role { get; set; }
        public string? Token { get; set; }
        public string? Status { get; set; }
    }
}
