using HealthClinique.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HealthClinique.Service.Patients
{
    public interface IPatientService
    {
    
        Task<ServiceResponse<bool>> CreatePatient(Patient patient);

        ServiceResponse<bool> DeletePatient(int id);

        ServiceResponse<Patient> GetPatientById(string id);

        List<Patient> GetAllPatient();

        ServiceResponse<bool> UpdatePatient(Patient patient);
    }
}
