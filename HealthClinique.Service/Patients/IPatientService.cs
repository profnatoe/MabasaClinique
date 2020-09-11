using HealthClinique.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinique.Service.Patients
{
    public interface IPatientService
    {
        ServiceResponse<bool> CreatePatient(Patient patient);

        ServiceResponse<bool> DeletePatient(int id);

        Patient GetPatientById(int id);

        List<Patient> GetAllPatient();

        ServiceResponse<bool> UpdatePatient(Patient patient);
    }
}
