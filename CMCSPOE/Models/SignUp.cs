using System.ComponentModel.DataAnnotations;

namespace CMCSPOE.Models
{
    public class SignUp
    {
        [Required]
        public string? Username { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
