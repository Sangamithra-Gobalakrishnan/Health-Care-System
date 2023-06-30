using HealthCareAPI.Models.DTO;
using HealthCareAPI.Models;

namespace HealthCareAPI.Interfaces
{
    public interface IPatientDTOUserAdapter
    {
        public Task<User> GetUserFromPatientDTOAsync(PatientDTO patientDTO,int count);
    }
}
