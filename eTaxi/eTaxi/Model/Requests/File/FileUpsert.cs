using Microsoft.AspNetCore.Http;

namespace Model.Requests
{
    public class FileUpsert
    {
        public IFormFile File { get; set; }
        public string Link { get; set; }
        public int UserId { get; set; }
    }
}
