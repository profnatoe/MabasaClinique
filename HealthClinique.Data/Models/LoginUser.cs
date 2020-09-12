using System.ComponentModel.DataAnnotations;

namespace HealthClinique.Data.Models
{
    public class LoginUser
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        [MaxLength(16)]
        public string Password { get; set; }
    }
}