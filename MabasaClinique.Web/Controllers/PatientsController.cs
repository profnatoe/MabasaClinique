using HealthClinique.Data.Models;
using HealthClinique.Service.Patients;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MabasaClinique.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]/")]
    [Authorize]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _patients;

        public PatientsController(IPatientService patientService)
        {
            _patients = patientService;
        }
        [HttpGet]
        public ActionResult GetAllPatients()
        {
            var results =  _patients.GetAllPatient();

            return Ok(results);
        }

        [HttpGet("{id}")]
        public ActionResult GetPatientById(string id)
        {
            return Ok(_patients.GetPatientById(id));
        }

        [HttpPost]
        public ActionResult CreatePatient([FromBody] Patient patient)
        {
            if(ModelState.IsValid)
                return Ok(_patients.CreatePatient(patient));
            return BadRequest("Model not valid");
        }

        [HttpDelete("{id}")]
        public ActionResult DeletePatient(int id)
        {
            return Ok(_patients.DeletePatient(id));
        }

        [HttpPut]
        public ActionResult UpdatePatient([FromBody] Patient patient)
        {
            return Ok(_patients.UpdatePatient(patient));
        }
    }
}