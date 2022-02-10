using System.ComponentModel.DataAnnotations;

namespace Model.Requests
{
    public class ApplicationUserRequest
    {
        [Required(ErrorMessage = "UserName is required.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
    }
}
