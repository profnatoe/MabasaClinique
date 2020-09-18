using HealthClinique.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinique.Service.Diagnosis
{
    public interface IPatientDiagnosisService
    {
        ServiceResponse<bool> Create(PatientTests patient);
        List<PatientTests> GetAllDiagnosis();
        ServiceResponse<PatientTests> GetById(int id);
        ServiceResponse<bool> Delete(int id);
    }
}
