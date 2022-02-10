using Model.Others;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAuthentication
    {
        public Task<SuccessLogin> Login(LoginModel model, bool isExternal=false);
        public Task<Response> Register(Register model);
        public Task<Response> RegisterAdmin(RegisterModel model);
        public Task<string> VerifyEmail(VerifyEmail User);
        public Task<bool> MobileVerifyEmail(MobileVerifyEmail User);

        public Task<Response> ForgotPassword(ForgotPassword model);
        public Task<Response> ResetPassword(ResetPassword model);
        public Task<Response> MobileResetPassword(MobileResetPassword model);
        // public void SendMobileVerificationMail(string email, int pin);

        public SuccessLogin Refresh(TokenApiModel tokenApiModel);
        string GenerateAccessToken(IEnumerable<Claim> claims);
        string GenerateRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
        Task<bool> ChangeEmail(int id, ChangeEmail request);
        Task<string> ConfirmChangeEmail(ConfirmChangeEmail request);
        Task<bool> ChangeEmailMobile(int id, ChangeEmail request);
        Task<Response> ConfirmChangeEmailMobile(ConfirmChangeEmail request);
        Task<bool> ChangePasswordFromSettings(int id, ChangePassword request);
        Task<bool> MobileCheckMail(string email);
        Task<bool> CheckPin(int id, int pin);
        Task<bool> DeactivateAccount(int id);


    }
}
