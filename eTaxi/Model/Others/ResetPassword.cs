using System.ComponentModel.DataAnnotations;

namespace Model.Others
{
    public class ResetPassword
    {
        [Required]
        public string Token { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 7)]
        public string Password { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 7)]
        public string ConfirmPassword { get; set; }

    }
}
