using Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Model.Dto
{
    public class UsersDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Pin { get; set; }
        public string UserType { get; set; }
        public DateTime UserCreatedTime { get; set; }
        public bool IsActive { get; set; }
        public bool VerifiedAccount { get; set; }


        public virtual ICollection<File> Files { get; set; }
        //Token
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}
