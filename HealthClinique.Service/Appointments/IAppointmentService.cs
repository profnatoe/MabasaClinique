using System.Collections.Generic;
using HealthClinique.Data.Models;

namespace HealthClinique.Service.Appointments
{
    public interface IAppointmentService
    {
        ServiceResponse<bool> CreateAppointment(Appointment appointment);

        ServiceResponse<bool> DeleteAppointment(int id);

        ServiceResponse<Appointment> GetAppointmentById(int id);

        List<Appointment> GetAllAppointments();

        ServiceResponse<Appointment> UpdateAppointment(Appointment appointment);

    }
}