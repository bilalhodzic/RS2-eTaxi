using System.ComponentModel.DataAnnotations;

namespace Model.Others
{
    public class MailSender
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Message { get; set; }

    }
}
