using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthClinique.Data.Models;
using HealthClinique.Service.Appointments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MabasaClinique.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointment;

        public AppointmentController(IAppointmentService appointment)
        {
            _appointment = appointment;
        }

        [HttpPost]
        public ActionResult Create([FromBody] Appointment appointment) => Ok(_appointment.CreateAppointment(appointment));

        [HttpGet("{id}")]
        public ActionResult GetById(int id) => Ok(_appointment.GetAppointmentById(id));

        [HttpGet]
        public ActionResult GetAll() => Ok(_appointment.GetAllAppointments());

        [HttpDelete("{id}")]
        public ActionResult Delete(int id) => Ok(_appointment.DeleteAppointment(id));

        [HttpPut]
        public ActionResult Update([FromBody] Appointment appointment) => Ok(_appointment.UpdateAppointment(appointment));
    }
}