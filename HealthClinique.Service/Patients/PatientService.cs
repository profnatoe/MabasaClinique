using HealthClinique.Data;
using HealthClinique.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClinique.Service.Patients
{
    public class PatientService : IPatientService
    {
        private readonly MabasaDbContext _db;
        private readonly ILogger<PatientService> _logger;

        public PatientService(MabasaDbContext db, ILogger<PatientService> logger)
        {
            _db = db;
            _logger = logger;
        }

        /// <summary>
        /// Creates a patient and save to the system
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<bool>> CreatePatient(Patient patient)
        {
            var now = DateTime.UtcNow;

            try
            {
                if(patient == null)
                {
                    return new ServiceResponse<bool>
                    {
                        Message = "Patient Model is null",
                        IsSuccess = false,
                        Time = now,
                        Data = false
                    };
                }
                patient.CreatedOn = now;
                patient.UpdatedOn = now;

                _db.Patients.Add(patient);
                await _db.SaveChangesAsync();

                return new ServiceResponse<bool>
                {
                    IsSuccess = true,
                    Data = true,
                    Message = $"Patient with Id {patient.Id} created successfully!",
                    Time = now
                };
            }
            catch(Exception e)
            {
                return new ServiceResponse<bool>
                {
                    Data = false,
                    Message = e.StackTrace,
                    IsSuccess = false,
                    Time = now
                };
            }
        }

        /// <summary>
        /// Delete a patient from the system using patientId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ServiceResponse<bool> DeletePatient(int id)
        {
            var now = DateTime.UtcNow;
            try
            {
                var patient = _db.Patients.Find(id);

                if(patient == null)
                {
                    return new ServiceResponse<bool>
                    {
                        Message = $"Could not find a patient with this Id {id}!",
                        Time = now,
                        IsSuccess = false,
                        Data = false
                    };
                }

                _db.Patients.Remove(patient);
                _db.SaveChanges();

                return new ServiceResponse<bool>
                {
                    Message = $"Patient with Id {id} has been removed successfully!",
                    Time = now,
                    IsSuccess = true,
                    Data = true
                };
            }
            catch(Exception e)
            {
                return new ServiceResponse<bool>
                {
                    Message = e.StackTrace,
                    Time = now,
                    IsSuccess = false,
                    Data = false
                };
            }
        }

        /// <summary>
        /// Retrieves all Patients in the system
        /// </summary>
        /// <returns></returns>
        public List<Patient> GetAllPatient()
        {
            return _db.Patients
                .Include(patient => patient.PrimaryAddress)
                .ToList();
        }

        /// <summary>
        /// Retrieves a single patient using patientId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ServiceResponse<Patient> GetPatientById(int id)
        {
            var patient =  _db.Patients.Find(id);
            var now = DateTime.UtcNow;

            if(patient == null)
            {
                return new ServiceResponse<Patient>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = $"Patient with Id: {id} was not found in the system",
                    Time = now
                };
            }

            return new ServiceResponse<Patient>
            {
                Data = patient,
                Message = $"Patient with Id: {id} has been found!",
                Time = now,
                IsSuccess = true
            };
        }

        /// <summary>
        /// Update a patient using a newly provided data
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        public ServiceResponse<bool> UpdatePatient(Patient patient)
        {
            var now = DateTime.UtcNow;

            try
            {
                var patientToUpdate = _db.Patients.Find(patient.Id);

                if(patientToUpdate == null)
                {
                    return new ServiceResponse<bool>
                    {
                        Message = $"Could not find a patient with this Id {patient.Id}!",
                        Time = now,
                        IsSuccess = false,
                        Data = false
                    };
                }

                patientToUpdate.Id = patient.Id;
                patientToUpdate.FirstName = patient.FirstName;
                patientToUpdate.LastName = patient.LastName;
                patientToUpdate.Age = patient.Age;
                patientToUpdate.Gender = patient.Gender;
                patientToUpdate.PrimaryAddress = patient.PrimaryAddress;
                patientToUpdate.UpdatedOn = now;
                patientToUpdate.IdentityNumber = patient.IdentityNumber;

                _db.Patients.Update(patientToUpdate);
                _db.SaveChanges();

                return new ServiceResponse<bool>
                {
                    Message = $"Successfully updated patient with id {patientToUpdate.Id}",
                    Time = now,
                    IsSuccess = true,
                    Data = true
                };
            }
            catch(Exception e)
            {
                return new ServiceResponse<bool>
                {
                    Message = e.StackTrace,
                    Time = now,
                    IsSuccess = false,
                    Data = false
                };
            }
        }
    }
}
