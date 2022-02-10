using Model.Others;
using System;
using System.Linq;

namespace Application.Authentication
{
    public partial class Authentication
    {
        public SuccessLogin Refresh(TokenApiModel tokenApiModel)
        {
            if (tokenApiModel is null)
            {
                throw new UserException("Invalid client request");
            }
            string accessToken = tokenApiModel.AccessToken;
            string refreshToken = tokenApiModel.RefreshToken;
            var principal = GetPrincipalFromExpiredToken(accessToken);
            var username = principal.Identity.Name; //this is mapped to the Name claim by default
            var user = _context.ApplicationUsers.SingleOrDefault(u => u.UserName == username || u.Email == username);
            if (user == null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
            {
                throw new UserException("Invalid client request");
            }
            var newAccessToken = GenerateAccessToken(principal.Claims);
            var newRefreshToken = GenerateRefreshToken();
            user.RefreshToken = newRefreshToken;
            _context.SaveChanges();
            return new SuccessLogin { Token = newAccessToken, RefreshToken = newRefreshToken };
        }
    }
}
