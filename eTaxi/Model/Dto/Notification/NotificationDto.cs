using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Dto
{
    public class NotificationDto
    {
        public int NotificationId { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedTime { get; set; }
        public string Text { get; set; }
    }
}
