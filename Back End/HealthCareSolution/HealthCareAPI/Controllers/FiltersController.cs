using HealthCareAPI.Interfaces;
using HealthCareAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace HealthCareAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FiltersController : ControllerBase
    {
        private readonly IFilterService<Doctor, Patient> _filterService;

        public FiltersController(IFilterService<Doctor,Patient> filterService)
        { 
            _filterService = filterService;
        }

        [HttpGet("GetAllDoctors")]
        [ProducesResponseType(typeof(ICollection<Doctor>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ICollection<Doctor>>> GetAllDoctors()
        {
            var doctors = await _filterService.GetAllDoctors();
            if (doctors != null)
                return Ok(doctors);
            return NotFound("No availability of doctors right now");
        }

        [HttpGet("GetAllPatients")]
        [ProducesResponseType(typeof(ICollection<Patient>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ICollection<Patient>>> GetAllPatients()
        {
            var patients = await _filterService.GetAllPatients();
            if (patients != null)
                return Ok(patients);
            return NotFound("No availability of patients right now");
        }
    }
}
