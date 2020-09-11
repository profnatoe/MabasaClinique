using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthClinique.Service.Patients;
using Microsoft.AspNetCore.Mvc;

namespace MabasaClinique.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]/")]
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
    }
}