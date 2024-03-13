using System.ComponentModel.DataAnnotations;

namespace MyWebProject.Core.Models
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(50, MinimumLength = 7)]
        public string Password { get; set; } = null!;

        public bool RememberMe { get; set; }
    }
}
