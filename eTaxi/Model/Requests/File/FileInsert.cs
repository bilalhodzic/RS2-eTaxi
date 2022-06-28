using Microsoft.AspNetCore.Http;


namespace Model.Requests
{
    public class FileInsert
    {
        public IFormFile File { get; set; }
        public string Link { get; set; }
        public string Type { get; set; }
        public int UserId { get; set; }

    }

}
