using Microsoft.AspNetCore.WebUtilities;
using Model.Others;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Authentication
{
    public partial class Authentication
    {

        public async Task<bool> ChangeEmail(int id, ChangeEmail request)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());

            if (user != null)
            {
                if (user.PasswordHash == null)
                {
                    throw new UserException(Messages.ChangeMailProvider);
                }

                var checkEmail = await _userManager.FindByEmailAsync(request.NewEmail);
                if (checkEmail == null)
                {
                    var token = await _userManager.GenerateChangeEmailTokenAsync(user, request.NewEmail);
                    var queryParams = new Dictionary<string, string>()
                    {
                        {"userId", id.ToString() },
                        {"token", token },
                        {"newEmail", request.NewEmail }
                    };

                    var url = _appSettings.ApiUrl;
                    var resource = "/Authentication/confirm-change-email";
                    var confLink = QueryHelpers.AddQueryString(resource, queryParams);

                    confLink = url + confLink;

                    var htmlCode = GetChangeEmailMessage(confLink);

                    var message = new EmailMessage(new string[] { request.NewEmail }, Messages.ChangeMail, htmlCode);

                    _EmailService.SendEmail(message);
                    return true;
                }
                else
                {
                    throw new UserException(Messages.MailExist);
                }
            }
            else
            {
                throw new UserException(Messages.UserNotExist);
            }
        }
    }
}
