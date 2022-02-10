using Model.Dto.Files;
using System;

namespace Model.Dto
{
    public class UsersDto
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserType { get; set; }
        public DateTime UserCreatedTime { get; set; }
    }
}
