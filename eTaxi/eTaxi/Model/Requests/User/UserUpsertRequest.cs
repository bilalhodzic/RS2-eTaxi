using System;
using System.ComponentModel.DataAnnotations;

namespace Model.Requests
{
    public class UserUpsertRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserType { get; set; }
        public DateTime UserCreatedTime { get; set; }


    }
}
