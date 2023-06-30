using HealthCareAPI.Interfaces;
using HealthCareAPI.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace HealthCareAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IManageUser<LoginDTO, DoctorDTO, PatientDTO,StatusDTO> _manageUser;

        public RegistrationController(IManageUser<LoginDTO, DoctorDTO, PatientDTO, StatusDTO> manageUser) 
        {
            _manageUser = manageUser;
        }

        [HttpPost("DoctorRegistration")]
        [ProducesResponseType(typeof(LoginDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<LoginDTO>> DoctorRegister(DoctorDTO doctorDTO)
        {
            var register = await _manageUser.DoctorRegistration(doctorDTO);
            if (register != null)
                return Ok(register);
            return BadRequest("Unable to register at this moment");
        }

        [HttpPost("PatientRegistration")]
        [ProducesResponseType(typeof(LoginDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<LoginDTO>> PatientRegister(PatientDTO patientDTO)
        {
            var register = await _manageUser.PatientRegistration(patientDTO);
            if (register != null)
                return Ok(register);
            return BadRequest("Unable to register at this moment");
        }

        [HttpPost("Login")]
        [ProducesResponseType(typeof(LoginDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<LoginDTO>> Login(LoginDTO loginDTO)
        {
            var login = await _manageUser.Login(loginDTO);
            if (login != null)
                return Ok(login);
            return BadRequest("Check your credentials and try again");
        }

        [HttpPut("ApproveDoctor")]
        [ProducesResponseType(typeof(LoginDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<LoginDTO>> ApproveDoctor(StatusDTO statusDTO)
        {
            var login = await _manageUser.ApproveDoctor(statusDTO);
            if (login != null)
                return Ok(login);
            return BadRequest("Cannot approve right now");
        }
    }
}
