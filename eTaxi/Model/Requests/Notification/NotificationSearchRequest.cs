﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Requests
{
    public class NotificationSearchRequest
    {
        public int UserId { get; set; }
        public DateTime CreatedTime { get; set; }
        public string Text { get; set; }
    }
}
