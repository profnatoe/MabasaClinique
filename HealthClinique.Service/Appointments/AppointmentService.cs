using System.Collections.Generic;
using HealthClinique.Data.Models;

namespace HealthClinique.Service.Appointments
{
    public class AppointmentService : IAppointmentService
    {
        public ServiceResponse<bool> CreateAppointment(Appointment appointment)
        {
            throw new System.NotImplementedException();
        }

        public ServiceResponse<bool> DeleteAppointment(int id)
        {
            throw new System.NotImplementedException();
        }

        public ServiceResponse<Appointment> GetAppointmentById(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Appointment> GetAllAppointments()
        {
            throw new System.NotImplementedException();
        }

        public ServiceResponse<Appointment> UpdateAppointment(Appointment appointment)
        {
            throw new System.NotImplementedException();
        }
    }
}