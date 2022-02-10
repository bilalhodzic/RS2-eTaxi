using System.Text;

namespace Application.Authentication
{
    public partial class Authentication
    {
        public static string GetVerificationMessage(string link)
        {
            StringBuilder email = new StringBuilder();
            email.Append("<body>"); email.Append("<div style=\"font-family: Bahnschrift Light; max-width: 500px; margin: auto; border: 1px solid rgba(143, 143, 143, 0.466); border-radius: 10px; overflow: hidden;\">");
            email.Append("<div style=\"padding: 10px 0; text-align: center; background-color: #E83741; color: white; \">");
            email.Append("<h2>Willkommen bei spiderjob</h2>");
            email.Append("</div>");
            email.Append("<div style=\"padding: 30px 40px; \">");
            email.Append("<h3 style=\"margin: 0; \">Lieber spiderjob-Nutzer,</h3>");
            email.Append("<p>vielen Dank, dass Sie sich bei Spider Job registriert haben.</p>");
            email.Append("<p>Um Ihre Registrierung abzuschließen, bestätigen Sie bitte Ihre E-Mail-Adresse.</p>");
            email.Append("<div style=\"text-align: center; margin: 30px 0; \">");
            email.Append("<a style=\"padding: 8px 16px; text-decoration: none; background: #E83741; border-radius: 4px; color: white; \" href=\"" + link + "\">Bestätige deine Registrierung</a>");
            email.Append("</div>");
            email.Append("<p>Mit der Bestätigung versichern Sie, dass Sie sich persönlich registriert haben und kein Missbrauch Ihrer E-Mail-Adresse vorliegt.</p>");
            email.Append("<p style=\"margin: 5px  0; \">Mit freundlichen Grüßen,</p>");
            email.Append("<p style=\"margin: 0; \">Euer Spider Job Team</p>");
            email.Append("</div>");
            email.Append("</div>");
            email.Append("</body>");
            return email.ToString();
        }
    }
}
