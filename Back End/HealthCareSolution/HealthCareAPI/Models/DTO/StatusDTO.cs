using System.ComponentModel.DataAnnotations;

namespace HealthCareAPI.Models.DTO
{
    public class StatusDTO
    {
        [Required]
        public string? DoctorID { get; set; }
    }
}
