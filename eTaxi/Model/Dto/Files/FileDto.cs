namespace Model.Dto
{
    public class FileDto
    {
        public int FileId { get; set; }
        public int UserId { get; set; }
        public string Url { get; set; }
        public string FileName { get; set; }
        public string OriginalName { get; set; }
        public string Type { get; set; }
    }
}
