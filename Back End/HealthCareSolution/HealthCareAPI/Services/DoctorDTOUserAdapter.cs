using HealthCareAPI.Interfaces;
using HealthCareAPI.Models;
using HealthCareAPI.Models.DTO;
using System.Security.Cryptography;
using System.Text;

namespace HealthCareAPI.Services
{
    public class DoctorDTOUserAdapter : IDoctorDTOUserAdapter
    {
        private readonly IGenerateUserId _generateDoctorId;

        public DoctorDTOUserAdapter(IGenerateUserId generateDoctorId) 
        {
            _generateDoctorId = generateDoctorId;
        }
        public async Task<User> GetUserFromDoctorDTOAsync(DoctorDTO doctorDTO, int count)
        {
            if(doctorDTO.Password != null)
            {
                var hmac = new HMACSHA512();
                doctorDTO.User.UserId = await _generateDoctorId.GenerateUserId("doctor",count);
                doctorDTO.User.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(doctorDTO.Password));
                doctorDTO.User.PasswordKey = hmac.Key;
                doctorDTO.User.Role = "doctor";
                doctorDTO.User.Status = "Not-Approved";
                return doctorDTO.User;
            }
            return null;
        }
    }
}
