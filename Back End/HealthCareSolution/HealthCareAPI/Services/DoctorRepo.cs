using HealthCareAPI.Interfaces;
using HealthCareAPI.Models;
using HealthCareAPI.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace HealthCareAPI.Services
{
    public class DoctorRepo : IDoctorRepo<Doctor>
    {
        private readonly HealthCareContext _healthCareContext;
        private readonly ILogger<DoctorRepo> _logger;

        public DoctorRepo(HealthCareContext healthCareContext , ILogger<DoctorRepo> logger) 
        { 
            _healthCareContext = healthCareContext;
            _logger = logger;
        }
        public async Task<Doctor?> Add(Doctor doctor)
        {
            try
            {
                _healthCareContext.Add(doctor);
                await _healthCareContext.SaveChangesAsync();
                return doctor;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public async Task<ICollection<Doctor>?> GetAll()
        {
            var doctors = await _healthCareContext.Doctors.ToListAsync();
            return doctors;
        }

    }
}
