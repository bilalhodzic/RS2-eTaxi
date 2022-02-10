using System.Collections.Generic;

#nullable disable

namespace Domain
{
    public partial class File
    {
        public int FileId { get; set; }
        public int UserId { get; set; }
        public string Url { get; set; }
        public string FileName { get; set; }
        public string OriginalName { get; set; }
        public string Type { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
