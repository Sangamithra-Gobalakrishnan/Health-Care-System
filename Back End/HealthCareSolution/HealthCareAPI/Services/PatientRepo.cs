using HealthCareAPI.Interfaces;
using HealthCareAPI.Models;
using HealthCareAPI.Models.Context;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace HealthCareAPI.Services
{
    public class PatientRepo : IPatientRepo<Patient>
    {
        private readonly HealthCareContext _healthCareContext;
        private readonly ILogger<PatientRepo> _logger;

        public PatientRepo(HealthCareContext healthCareContext, ILogger<PatientRepo> logger)
        {
            _healthCareContext = healthCareContext;
            _logger = logger;
        }
        public async Task<Patient?> Add(Patient patient)
        {
            try
            {
                _healthCareContext.Add(patient);
                await _healthCareContext.SaveChangesAsync();
                return patient;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public async Task<ICollection<Patient>?> GetAll()
        {
            var patients = await _healthCareContext.Patients.ToListAsync();
            return patients;
        }
    }
}
