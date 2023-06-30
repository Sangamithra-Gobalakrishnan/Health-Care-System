using HealthCareAPI.Interfaces;
using HealthCareAPI.Models;

namespace HealthCareAPI.Services
{
    public class FilterService : IFilterService<Doctor, Patient>
    {
        private readonly IDoctorRepo<Doctor> _doctorRepo;
        private readonly IPatientRepo<Patient> _patientRepo;

        public FilterService(IDoctorRepo<Doctor> doctorRepo,
                             IPatientRepo<Patient> patientRepo)
        {
            _doctorRepo = doctorRepo;
            _patientRepo = patientRepo;
        }
        public async Task<ICollection<Doctor>?> GetAllDoctors()
        {
            var doctors = await _doctorRepo.GetAll();
            if (doctors != null)
                return doctors;
            return null;
        }

        public async Task<ICollection<Patient>?> GetAllPatients()
        {
            var patients = await _patientRepo.GetAll();
            if (patients != null)
                return patients;
            return null;
        }
    }
}
