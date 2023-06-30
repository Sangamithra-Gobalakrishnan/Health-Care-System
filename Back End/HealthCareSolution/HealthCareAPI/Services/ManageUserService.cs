using HealthCareAPI.Interfaces;
using HealthCareAPI.Models;
using HealthCareAPI.Models.DTO;
using System.Security.Cryptography;
using System.Text;

namespace HealthCareAPI.Services
{
    public class ManageUserService : IManageUser<LoginDTO,DoctorDTO,PatientDTO,StatusDTO>
    {
        private readonly IDoctorDTOUserAdapter _doctorDTOUserAdapter;
        private readonly IPatientDTOUserAdapter _patientDTOUserAdapter;
        private readonly IUserRepo<User,string> _userRepo;
        private readonly IDoctorRepo<Doctor> _doctorRepo;
        private readonly IPatientRepo<Patient> _patientRepo;
        private readonly IGenerateToken<LoginDTO> _generateToken;

        public ManageUserService(IDoctorDTOUserAdapter doctorDTOUserAdapter,
                          IPatientDTOUserAdapter patientDTOUserAdapter,
                          IUserRepo<User,string> userRepo,
                          IDoctorRepo<Doctor> doctorRepo,
                          IPatientRepo<Patient> patientRepo,
                          IGenerateToken<LoginDTO> generateToken
                          ) 
        { 
            _doctorDTOUserAdapter = doctorDTOUserAdapter;
            _patientDTOUserAdapter = patientDTOUserAdapter;
            _userRepo = userRepo;
            _doctorRepo = doctorRepo;
            _patientRepo = patientRepo;
            _generateToken = generateToken;
        }

        public async Task<LoginDTO?> ApproveDoctor(StatusDTO statusDTO)
        {
            LoginDTO? login = null;
            var doctor = await _userRepo.Get(statusDTO.DoctorID);
            if (doctor != null)
            {
                if (doctor.Status == "Approved")
                    doctor.Status = "Not-Approved";
                else
                    doctor.Status = "Approved";
                var result = await _userRepo.Update(doctor);
                if (result != null)
                {
                    login.UserId = result.UserId;
                    login.Status = result.Status;
                }
            }
            return null;
        }

        public async Task<LoginDTO?> DoctorRegistration(DoctorDTO doctorDTO)
        {
            LoginDTO? login = null;
            var doctors = await _doctorRepo.GetAll();
            var userNew = await _doctorDTOUserAdapter.GetUserFromDoctorDTOAsync(doctorDTO, doctors.Count());
            var userResult = await _userRepo.Add(userNew);
            doctorDTO.Age = DateTime.Today.Year - new DateTime(doctorDTO.DateOfBirth.Year, doctorDTO.DateOfBirth.Month, doctorDTO.DateOfBirth.Day).Year;
            var doctorResult = await _doctorRepo.Add(doctorDTO);
            if (userResult != null && doctorResult != null)
            {
                login = new LoginDTO();
                login.UserId = userResult.UserId;
                login.Role = userResult.Role;
                login.Status = userResult.Status;
                login.Token = _generateToken.GenerateToken(login);
            }
            return login;
        }

        public async Task<LoginDTO?> Login(LoginDTO loginDTO)
        {
            LoginDTO? login = null;
            var userData = await _userRepo.GetIDByEmail(loginDTO.Email);
            if (userData != null)
            {
                var hmac = new HMACSHA512(userData.PasswordKey);
                var userPass = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDTO.Password));
                for (int i = 0; i < userPass.Length; i++)
                {
                    if (userPass[i] != userData.PasswordHash[i])
                        return null;
                }
                login = new LoginDTO();
                login.UserId = userData.UserId;
                login.Role = userData.Role;
                login.Status = userData.Status;
                login.Token = _generateToken.GenerateToken(login);
            }
            return login;
        }

        public async Task<LoginDTO?> PatientRegistration(PatientDTO patientDTO)
        {
            LoginDTO? login = null;
            var patients = await _patientRepo.GetAll();
            var userNew = await _patientDTOUserAdapter.GetUserFromPatientDTOAsync(patientDTO,patients.Count());
            var userResult = await _userRepo.Add(userNew);
            patientDTO.Age = DateTime.Today.Year - new DateTime(patientDTO.DateOfBirth.Year, patientDTO.DateOfBirth.Month, patientDTO.DateOfBirth.Day).Year;
            var patientResult = await _patientRepo.Add(patientDTO);
            if (userResult != null && patientResult != null)
            {
                login = new LoginDTO();
                login.UserId = userResult.UserId;
                login.Role = userResult.Role;
                login.Status = userResult.Status;
                login.Token = _generateToken.GenerateToken(login);
            }
            return login;
        }
    }
}
