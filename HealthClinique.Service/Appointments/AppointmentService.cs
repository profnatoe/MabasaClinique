using System;
using System.Collections.Generic;
using System.Linq;
using HealthClinique.Data;
using HealthClinique.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthClinique.Service.Appointments
{
    public class AppointmentService : IAppointmentService
    {
        private readonly MabasaDbContext _db;

        public AppointmentService(MabasaDbContext db)
        {
            _db = db;
        }
        public ServiceResponse<bool> CreateAppointment(Appointment appointment)
        {
            var now = DateTime.UtcNow;

            try
            {
                var appoint = new Appointment
                {
                    CreatedOn = now,
                    UpdatedOn = now,
                    IsFirstTime = appointment.IsFirstTime,
                    IsSick = appointment.IsSick,
                    AppointmentType = appointment.AppointmentType,
                };

                _db.Appointment.Add(appoint);

                _db.SaveChangesAsync();
                
            }
            catch(Exception e)
            {
                return new ServiceResponse<bool>
                {
                    Data = false,
                    Message = e.StackTrace,
                    Time = now,
                    IsSuccess = false
                };
            }

            return new ServiceResponse<bool>
            {
                Data = false,
                Message = "Could not create an appointment",
                Time = now,
                IsSuccess = false
            };
        }

        public ServiceResponse<bool> DeleteAppointment(int id)
        {
            var now = DateTime.UtcNow;

            var appointment = _db.Appointment.Find(id);
            
            if(appointment != null)
            {
                try
                {
                
                    _db.Appointment.Remove(appointment);

                    _db.SaveChangesAsync();

                    return new ServiceResponse<bool>
                    {
                        IsSuccess = true,
                        Message = "Successfully Removed Appointment",
                        Time = now,
                        Data = true,
                    };
                }
                catch(Exception e)
                {
                    return new ServiceResponse<bool>
                    {
                        IsSuccess = false,
                        Message = e.StackTrace,
                        Time = now,
                        Data = false,
                    };
                }

               
            }

            return new ServiceResponse<bool>
            {
                IsSuccess = false,
                Message = $"Could not find Appointment with this id: {id}",
                Data = false,
                Time = now
            };
        }

        public ServiceResponse<Appointment> GetAppointmentById(int id)
        {
            var now = DateTime.UtcNow;

            var appointment = _db.Appointment
                .Where(x => x.Id == id)
                .Include(x => x.PatientDigsosis)
                .FirstOrDefault();

            if(appointment != null)
                return new ServiceResponse<Appointment>
                {
                    Data = appointment,
                    IsSuccess = true,
                    Message = "Found Appointment",
                    Time = now
                };
            return new ServiceResponse<Appointment>
            {
                Data = null,
                Message = "could not find appointment with specified Id",
                IsSuccess = false,
                Time = now
            };
        }

        public List<Appointment> GetAllAppointments()
        {
            return _db.Appointment.Include(x => x.PatientDigsosis).ToList();
        }

        public ServiceResponse<Appointment> UpdateAppointment(Appointment appointment)
        {
            throw new System.NotImplementedException();
        }
    }
}