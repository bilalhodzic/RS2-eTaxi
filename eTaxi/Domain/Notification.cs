using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public partial class Notification
    {
        public Notification()
        {
            CreatedTime = DateTime.Now;
        }
        public int NotificationId { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedTime { get; set; }
        public string Text { get; set; }

        public virtual ApplicationUser  User{ get; set; }


    }
}
