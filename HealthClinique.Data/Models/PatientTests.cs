using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinique.Data.Models
{
    public class PatientTests
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }

        public bool IsBloodPressure { get; set; }
        public bool IsHIV { get; set; }
        public bool IsSugarDiabetes { get; set; }
        public bool IsCancer { get; set; }
        public string Prescription { get; set; }

        public DateTime NextAppointmentDate { get; set; }

        public int AppointmentId { get; set; }
    }
}
