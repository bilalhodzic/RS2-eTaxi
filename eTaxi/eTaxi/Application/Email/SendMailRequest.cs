using Model.Others;
using Domain;
using System.Linq;

namespace Application.Email
{
    public partial class Email
    {
        public Response SendMail(MailSender model)
        {
            var message = new EmailMessage(new string[] { _emailConfig.To }, "Unterstützung", GetSendMailMessage(model));
            SendEmail(message);

            return new Response { Status = Messages.Success, Message = "Nachricht wurde erfolgreich an die E-Mail gesendet" };
        }
        
        public Response SendConnMail(VisitMail model)
        {
            var message = new EmailMessage(new string[] { _emailConfig.To }, "Unterstützung", GetSendConnMailMessage(model));
            SendEmail(message);
            ApplicationUser ValidatorUsers = _context.ApplicationUsers.Where(x => x.Email == model.Email).FirstOrDefault();

           
            return new Response { Status = Messages.Success, Message = "Nachricht wurde erfolgreich an die E-Mail gesendet" };
        }
    }

}
