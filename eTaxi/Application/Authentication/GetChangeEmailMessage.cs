using System.Text;

namespace Application.Authentication
{
    public partial class Authentication
    {
        public static string GetChangeEmailMessage(string link)
        {
            StringBuilder email = new StringBuilder();
            email.Append("<body>");
            email.Append("<div style=\"font-family: Bahnschrift Light; max-width: 500px; margin: auto; border: 1px solid rgba(143, 143, 143, 0.466); border-radius: 10px; overflow: hidden;\">");
            email.Append("<div style=\"padding: 10px 0; text-align: center; background-color: #E83741; color: white; \">");
            email.Append("<h2>Willkommen bei spiderjob</h2>");
            email.Append("</div>");
            email.Append("<div style=\"padding: 30px 40px; \">");
            email.Append("<h3 style=\"margin: 0; \">Lieber spiderjob-Nutzer,</h3>");
            email.Append("<p>Es wurde eine Änderungsanfrage für Ihre E-Mail-Adresse gestellt.</p>");
            email.Append("<p>Wenn Sie diese Anfrage nicht gestellt haben, ignorieren Sie diese E-Mail einfach. Klicken Sie andernfalls auf die Schaltfläche Bestätigen, um Ihre E-Mail-Adresse zu ändern</p>");
            email.Append("<div style=\"text-align: center; margin: 30px 0; \">");
            email.Append("<a style=\"padding: 8px 16px; text-decoration: none; background: #E83741; border-radius: 4px; color: white; \" href=\"" + link + "\">Bestätigen Sie</a>");
            email.Append("</div>");
            email.Append("<p style=\"margin: 5px  0; \">Mit freundlichen Grüßen,</p>");
            email.Append("<p style=\"margin: 0; \">Euer spiderjob-Team</p>");
            email.Append("</div>");
            email.Append("</div>");
            email.Append("</body>");
            return email.ToString();
        }

    }
}
