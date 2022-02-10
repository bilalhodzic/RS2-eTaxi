using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Utils;
using Model.Others;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;

namespace Application.Email
{
    public partial class Email
    {
        [Obsolete]
        public void SendEmail(EmailMessage message)
        {
            var emailMessage = CreateEmailMessage(message);

            SendEmail(emailMessage);
        }

        [Obsolete]
        private void SendEmail(MimeMessage mailMessage)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                     client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                     client.CheckCertificateRevocation = false;
                     client.SslProtocols = SslProtocols.Ssl3 | SslProtocols.Ssl2 | SslProtocols.Tls | SslProtocols.Tls11 | SslProtocols.Tls12;
                     client.Connect(_emailConfig.SmtpServer, _emailConfig.Port, _emailConfig.SSL == 0 ? false : true);
                     client.AuthenticationMechanisms.Remove("XOAUTH2");
                     client.Authenticate(_emailConfig.UserName, _emailConfig.Password);
                     client.Send(mailMessage);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error: {ex.Message}");
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }
        }
    }
}
