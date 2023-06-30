using HealthCareAPI.Interfaces;
using HealthCareAPI.Models;
using HealthCareAPI.Models.DTO;
using System.Security.Cryptography;
using System.Text;

namespace HealthCareAPI.Services
{
    public class PatientDTOUserAdapter : IPatientDTOUserAdapter
    {
        private readonly IGenerateUserId _generatePatientId;

        public PatientDTOUserAdapter(IGenerateUserId generatePatientId)
        {
            _generatePatientId = generatePatientId;
        }
        public async Task<User> GetUserFromPatientDTOAsync(PatientDTO patientDTO,int count)
        {
            if (patientDTO.Password != null)
            {
                var hmac = new HMACSHA512();
                patientDTO.User.UserId = await _generatePatientId.GenerateUserId("patient",count);
                patientDTO.User.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(patientDTO.Password));
                patientDTO.User.PasswordKey = hmac.Key;
                patientDTO.User.Role = "patient";
                return patientDTO.User;
            }
            return null;
        }
    }
}
