using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HealthClinique.Data.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; }
        
        [MaxLength(50)]
        public string LastName { get; set; }
        
        [MaxLength(10)]
        public string Gender { get; set; }
        public int Age { get; set; }
        public PatientAddress PrimaryAddress { get; set; }
        
        [Required]
        public string IdentityNumber { get; set; }

       
    }
}
