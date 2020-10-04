using HealthClinique.Data;
using HealthClinique.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealthClinique.Service.Diagnosis
{
    public class PatientDiagnosisService : IPatientDiagnosisService
    {
        private readonly MabasaDbContext _db;

        public PatientDiagnosisService(MabasaDbContext db)
        {
            _db = db;
        }

        public ServiceResponse<bool> Create(PatientTests patient, int appointmentId)
        {
            var now = DateTime.UtcNow;
            var appointment = _db.Appointment.Find(appointmentId);

            if (appointment != null)
            {
                try
                {
                    var tests = new PatientTests
                    {
                        IsBloodPressure = patient.IsBloodPressure,
                        IsCancer = patient.IsCancer,
                        IsHIV = patient.IsHIV,
                        Prescription = patient.Prescription,
                        IsSugarDiabetes = patient.IsSugarDiabetes,
                        NextAppointmentDate = patient.NextAppointmentDate,
                        CreatedOn = now,
                        UpdatedOn = now,
                        AppointmentId = appointment.Id
                    };

                    _db.PatientTests.Add(tests);
                    _db.SaveChanges();

                    return new ServiceResponse<bool>
                    {
                        IsSuccess = true,
                        Message = "Success!",
                        Time = now,
                        Data = true
                    };
                }
                catch (Exception e)
                {
                    return new ServiceResponse<bool>
                    {
                        IsSuccess = false,
                        Message = e.StackTrace,
                        Time = now,
                        Data = false
                    };
                }
            }
            else
            {
                return new ServiceResponse<bool>
                {
                    Data = false,
                    Message = "Could not find Appointment with that Id",
                    IsSuccess = false,
                    Time = now
                };
            }
        }

        public ServiceResponse<bool> Delete(int id)
        {
            var tests = _db.PatientTests.Find(id);
            var now = DateTime.UtcNow;

            if(tests != null)
            {
                _db.PatientTests.Remove(tests);
                _db.SaveChanges();

                return new ServiceResponse<bool>
                {
                    IsSuccess = true,
                    Message = "Success!",
                    Time = now,
                    Data = true
                };
            }
            return new ServiceResponse<bool>
            {
                IsSuccess = false,
                Message = "Diagnosis Results with specified Id do not exist!",
                Time = now,
                Data = false
            };
        }

        public List<PatientTests> GetAllDiagnosis()
        {
            return _db.PatientTests.ToList();
        }

        public ServiceResponse<PatientTests> GetById(int id)
        {
            var diagnosis = _db.PatientTests.Find(id);
            var now = DateTime.UtcNow;

            if (diagnosis != null)
                return new ServiceResponse<PatientTests>
                {
                    Data = diagnosis,
                    Message = "Found!",
                    IsSuccess = true,
                    Time = now
                };
            return new ServiceResponse<PatientTests>
            {
                Data = null,
                Time = now,
                Message = "Diagnosis Results with specified Id not Found!",
                IsSuccess = false
            };
        }
    }
}
