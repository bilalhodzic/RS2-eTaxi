using Model.Others;

namespace Application.Authentication
{
    public partial class Authentication
    {
        private void SendMobileVerificationMail(string email, int pin)
        {


            var htmlCode = GetMobileVerificationMessage(pin.ToString());

            var message = new EmailMessage(new string[] { email }, "Verifikacija putem e-pošte ", htmlCode);

            _EmailService.SendEmail(message);

        }
    }
}
