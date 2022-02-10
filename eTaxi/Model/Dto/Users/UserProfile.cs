using Model.Dto.Files;

namespace Model.Dto.Users
{
    public class UserProfile
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Number { get; set; }
        public FileBasic Photo { get; set; }
    }
}
