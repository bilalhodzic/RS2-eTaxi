using FirebaseAdmin;
using FirebaseAdmin.Auth;
using Google.Apis.Auth.OAuth2;
using Model.Others;
using System;
using System.Linq;
using System.Threading.Tasks;
namespace Application.Users
{
    public partial class Users
    {
        public async Task<bool> NumberVerification(string uid)
        {
            var userId = int.Parse(_httpContextAccessor.HttpContext.User.FindFirst("UserId").Value);
           
            if (FirebaseApp.DefaultInstance == null)
            {
                FirebaseApp.Create(new AppOptions()
                {

                    Credential = GoogleCredential.GetApplicationDefault(),
                    ProjectId = "rezervacija-app",
                });
            }
            //"TIL0CICdzvN4dcoLsAA0HJd9Oo33"
            UserRecord userRecord = await FirebaseAuth.DefaultInstance.GetUserAsync(uid);
            var user = _context.ApplicationUsers.Where(x => x.PhoneNumber == userRecord.PhoneNumber).FirstOrDefault();
            if (user != null)
                throw new UserException("Broj se već koristi.");
            if (userRecord != null) {
                var User = _context.ApplicationUsers.Find(userId);
                User.PhoneNumber = userRecord.PhoneNumber;
                User.PhoneNumberConfirmed = true;
                _context.SaveChanges();
                return true;
            }
            throw new UserException(Messages.InternalError);
        }
    }
}
