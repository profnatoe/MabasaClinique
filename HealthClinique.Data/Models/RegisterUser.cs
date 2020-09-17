using System.ComponentModel.DataAnnotations;

namespace HealthClinique.Data.Models
{
    public class RegisterUser
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        [MaxLength(16)]
        public string Password { get; set; }
       
        [Required]
        [MaxLength(16)]
        public string ConfirmPassword { get; set; }

        [Required]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(10)]
        public string Gender { get; set; }
        
        public int Age { get; set; }
        
        [Required]
        public string IdentityNumber { get; set; }
    }
}