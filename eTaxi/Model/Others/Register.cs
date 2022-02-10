using System.ComponentModel.DataAnnotations;

namespace Model.Others
{
    public class Register
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required(ErrorMessage = "Username  is required.")]
        public string UserName { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }

        [MinLength(7,ErrorMessage = "Minimum 7 characters required.")]
        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [MinLength(7)]
        [Required(ErrorMessage = "Confirm password type is required.")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "User type is required.")]
        public int UserType { get; set; }
        public bool IsWeb { get; set; }
    }
}
