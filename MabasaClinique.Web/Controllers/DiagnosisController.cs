using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthClinique.Data.Models;
using HealthClinique.Service.Diagnosis;
using Microsoft.AspNetCore.Mvc;

namespace MabasaClinique.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]/results/")]
    public class DiagnosisController : ControllerBase
    {
        private readonly IPatientDiagnosisService _diagnosis;

        public DiagnosisController(IPatientDiagnosisService diagnosis)
        {
            _diagnosis = diagnosis;
        }

        [HttpPost]
        public ActionResult Create([FromBody] PatientTests tests) => Ok(_diagnosis.Create(tests));

        [HttpGet("{id}")]
        public ActionResult GetById(int id) => Ok(_diagnosis.GetById(id));

        [HttpGet]
        public ActionResult GetAll() => Ok(_diagnosis.GetAllDiagnosis());

        [HttpDelete("{id}")]
        public ActionResult Delete(int id) => Ok(_diagnosis.Delete(id));
    }
}