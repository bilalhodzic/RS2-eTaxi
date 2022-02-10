using Model.Others;

namespace Application.Interfaces
{
    public interface IEmail
    {
        void SendEmail(EmailMessage message);
        public Response SendMail(MailSender model);
        public Response SendConnMail(VisitMail model);
    }
}
