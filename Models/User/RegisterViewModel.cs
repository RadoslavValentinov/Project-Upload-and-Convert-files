using System.ComponentModel.DataAnnotations;

namespace UploadFiles.Models.User
{
    public class RegisterViewModel
    {

        [StringLength(100, MinimumLength = 3)]
        public string FirstName { get; set; } = null!;


        [StringLength(3, MinimumLength = 100)]
        public string LastName { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(100, MinimumLength = 7)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Required]
        [Compare(nameof(Password))]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = null!;
    }
}
