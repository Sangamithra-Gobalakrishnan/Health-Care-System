using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCareAPI.Models
{
    public class Patient
    {
        [Key]
        public string? Id { get; set; }
        [ForeignKey("Id")]
        public User? User { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = "Date of birth is required.")]
        [Column(TypeName = "date")]
        public DateTime DateOfBirth { get; set; }

        public int? Age { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        public string? Address { get; set; }
    }
}
