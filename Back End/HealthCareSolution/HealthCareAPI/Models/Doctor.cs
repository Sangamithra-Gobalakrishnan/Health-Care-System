using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HealthCareAPI.Models
{
    public class Doctor
    {
        [Key]
        public string? Id { get; set; }
        [ForeignKey("Id")]
        public User? User { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = "Specialty is required.")]
        public string? Specialty { get; set; }

        [Required(ErrorMessage = "Years of experience is required.")]
        [Range(0, 100, ErrorMessage = "Years of experience must be between 0 and 100.")]
        public int YearsOfExperience { get; set; }

        [Required(ErrorMessage = "Date of birth is required.")]
        [Column(TypeName = "date")]
        public DateTime DateOfBirth { get; set; }
        public int? Age { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        public string? Address { get; set; }

        [Required(ErrorMessage = "City is required.")]
        public string? City { get; set; }
    }
}
