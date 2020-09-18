using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinique.Data.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }


        public bool IsSick { get; set; }
        public bool IsFirstTime { get; set; }
        public string AppointmentType { get; set; }
        public PatientTests PatientDigsosis { get; set; }
    }
}
