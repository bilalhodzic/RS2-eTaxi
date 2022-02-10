using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Authentication
{
    public partial class Authentication
    {
        public static string GetMobileVerificationMessage(string link)
        {
            StringBuilder email = new StringBuilder();
            email.Append("<div style=\"font-family: Bahnschrift Light;max-width: 500px;margin: 20px auto auto auto;border: 1px solid rgb(43, 222, 168);border-radius: 10px;overflow: hidden;\">");
            email.Append("<div style=\"padding: 10px 0; text-align: center; background-color: #2bdea8; border-radius: 9px 9px 0 0; border: 0px solid rgb(43, 222, 168)\">");
            email.Append("<img src='https://ftp.rezervacija.app/api/public/dl/G7BUvfWn?inline=true' style=\"width: 32px\" />");
            email.Append("</div>");
            email.Append("<div style=\"padding: 30px 40px\">");
            email.Append("<h2>Poštovani,</h2>");
            email.Append("<p>Hvala Vam što ste izvršili registraciju.</p>");
            email.Append("<p>Da dovršite registraciju, molimo Vas da potvrdite svoju email adresu.</p>");
            email.Append($"<h3 style=\"text-align: center; margin: 30px 0\">{link}</h3>");
            email.Append("<p>Potvrdom dokazujete da ste se uspješno registrovali i da Vaša email adresa nije zloupotrebljena. </p>");
            email.Append("<p>Srdačan pozdrav.</p>");
            email.Append("</div>");
            email.Append("<div style=\"text-align: center\">");
            email.Append("<a href='https://makilio.com/' style=\"text-decoration: none;font-weight: bold;color: #fff;text-align: center;display: inline-block;background: #2bdea8;padding: 7px 30px;border-radius: 10px 10px 0 0;\" target = '_blank' rel = 'noreferrer'>");
            email.Append("<p style=\"margin: 0\">Powered by</p>");
            email.Append("<img src='https://www.rezervacija.app/wp-content/uploads/makilio-logo-white.png' style=\"width: 114px\"/>");
            email.Append("</a>");
            email.Append("</div>");
            email.Append("</div>");
            return email.ToString();
        }
    }
}
