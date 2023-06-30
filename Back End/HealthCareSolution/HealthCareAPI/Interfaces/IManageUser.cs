using HealthCareAPI.Models.DTO;

namespace HealthCareAPI.Interfaces
{
    public interface IManageUser<L,D,P,S>
    {
        public Task<L?> Login(L loginDTO);
        public Task<L?> DoctorRegistration(D doctorDTO);
        public Task<L?> PatientRegistration(P patientDTO);
        public Task<L?> ApproveDoctor(S statusDTO);
    }
}
