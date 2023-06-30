using HealthCareAPI.Models;
using HealthCareAPI.Models.DTO;

namespace HealthCareAPI.Interfaces
{
    public interface IDoctorDTOUserAdapter
    {
        public Task<User> GetUserFromDoctorDTOAsync(DoctorDTO doctorDTO,int count);
    }
}
