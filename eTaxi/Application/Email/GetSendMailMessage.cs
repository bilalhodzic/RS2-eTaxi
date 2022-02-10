using Model.Others;
using System.Text;

namespace Application.Email
{
    public partial class Email
    {
        public static string GetSendMailMessage(MailSender sender)
        {
            StringBuilder email = new StringBuilder();
            email.Append("<body>");
            email.Append("<div style=\"font-family: Bahnschrift Light; max-width: 500px; margin: auto; border: 1px solid rgba(143, 143, 143, 0.466); border-radius: 10px; overflow: hidden;\">");
            email.Append("<div style=\"padding: 10px 0; text-align: center; background-color: #E83741; color: white; \">");
            email.Append($"<h3>Name: {sender.FullName}  <br>Email: {sender.Email}");
            email.Append("</div>");
            email.Append("<div style=\"padding: 30px 40px; \">");
            email.Append($"<h4 style=\"margin: 5px 0; font-family:'Arial' \">{sender.Message}</h4>");
            email.Append("</div>");
            email.Append("</div>");
            email.Append("</body>");
            return email.ToString();
        }

        private string GetSendConnMailMessage(VisitMail sender)
        {

             StringBuilder email = new StringBuilder();
            email.Append("<div style = \"width: 800px; height: 330px; background-color: white; display: flex; justify-content: center; align-items: center;\">");
            email.Append("<div style = \"width: 30%; height: 100%; border-right: 1px solid #E83741; display: flex; justify-content: center; align-items: center; margin: 0 3%; padding-right: 5%;\">");
            email.Append($"<img src='{_applicationSettings.ApiUrl+ "/Images/sj-logo.png"}' style =\" width: 100%;height: auto;\"/>");
            email.Append("</div>");
            email.Append("<div style =\"width:70%; height:100%; display:block; align-items:flex-start; padding:0 5%;\">");
            email.Append("<h2 style =\"color: #FF9966;font-Weight: bold; font-size: 18px; line-height: 27px;text-transform: uppercase;\"> New registration </h2>");
            email.Append($"<h1 style =\"color: #e8r741;font-Weight: bold; font-size: 24px; line-height: 36px;letter-spacing: 0.02em;\"> {sender.FirstName +" "+ sender.LastName} </h1>");
            email.Append($"<h3 style =\"color: rgba(255, 94, 98, 1); font-Weight: 600; font-size: 14px; line-height: 21px;letter-spacing: 0.02em;margin-top: -3%; margin-bottom: 5%;\"> {sender.Position} </h3>");
            email.Append("<div style =\"width:100%; display:block; justify-content: flex-start;align-items: center;\">");
            email.Append("<div style =\"width: 100%;display:flex; justify-content: flex-start; align-items: center;\">");
            email.Append($"<p style =\" width: 100%;margin: 0 0 5% 0;color: rgba(232, 55, 65, 1);font-weight: 500; font-size: 18px;line-height: 27px;\"> {sender.Email} </ p >");
            email.Append("</div>");
            email.Append("<div style =\"width: 100%;display: flex; justify-content: flex-start; align-items: center; \">");
            email.Append($"<p style =\"  width: 100%;margin: 0 0 5% 0; color: rgba(232, 55, 65, 1);font-weight: 500; font-size: 18px; line-height:27px; \">  {sender.Mobile} </ p >");
            email.Append("</div>");
            email.Append("<div style =\"width: 100%;display: flex; justify-content: flex-start;  align-items: center;\">");
            email.Append($"<p style =\"width: 100%;margin: 0 0 5% 0;color: rgba(232, 55, 65, 1);font-weight: 500; font-size: 18px; line-height: 27px; \">  {sender.Company} </ p >");
            email.Append("</div>");
            email.Append("<div style =\"width: 100%;display: flex; justify-content: flex-start;  align-items: center;\">");
            email.Append($"<p style =\"width: 100%;margin: 0 0 5% 0;color: rgba(232, 55, 65, 1);font-weight: 500; font-size: 18px; line-height: 27px; \">  {sender.Package} </ p >");
            email.Append("</div>");
            email.Append("</div>");
            email.Append("</div>");
            email.Append("</div>");
            return email.ToString();

        }
    }
}
