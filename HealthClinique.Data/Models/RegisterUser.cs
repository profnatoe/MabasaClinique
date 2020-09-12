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
    }
}