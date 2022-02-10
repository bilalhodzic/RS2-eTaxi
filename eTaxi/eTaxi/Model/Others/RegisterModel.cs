using System.ComponentModel.DataAnnotations;

namespace Model.Others
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "User Name is required.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }

        [MinLength(4)]
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }

        [MinLength(4)]
        [Required(ErrorMessage = "User type is required.")]
        public string ConfirmPassword { get; set; }
    }
}
