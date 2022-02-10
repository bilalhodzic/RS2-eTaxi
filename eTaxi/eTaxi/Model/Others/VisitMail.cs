using System.ComponentModel.DataAnnotations;

namespace Model.Others
{
    public class VisitMail
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Position { get; set; }
        [Required]
        public string Mobile { get; set; }
        [Required]
        public string Company { get; set; }
        public string Package { get; set; }
        public int? PackageId { get; set; }


    }
}
