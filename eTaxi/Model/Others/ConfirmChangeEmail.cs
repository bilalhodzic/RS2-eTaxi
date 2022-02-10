namespace Model.Others
{
    public class ConfirmChangeEmail
    {
        public int UserId { get; set; }
        public string Token { get; set; }
        public string NewEmail { get; set; }
    }
}
