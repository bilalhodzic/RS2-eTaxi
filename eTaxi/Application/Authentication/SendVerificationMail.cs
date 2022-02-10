using Microsoft.AspNetCore.WebUtilities;
using Model.Others;
using System.Collections.Generic;
using System.Web;

namespace Application.Authentication
{
    public partial class Authentication
    {
        private void SendVerificationMail(string token, int userId, string email)
        {

            var queryParams = new Dictionary<string, string>()
                {
                {"userId", userId.ToString() },
                {"token", HttpUtility.UrlEncode(token) }
                };
            var confLink = QueryHelpers.AddQueryString(_appSettings.ApiUrl + "/Authentication/verify-email", queryParams);
            var htmlCode = GetVerificationMessage(confLink);

            var message = new EmailMessage(new string[] { email }, "Verifikacija putem e-pošte ", htmlCode);

            _EmailService.SendEmail(message);

        }
    }
}
