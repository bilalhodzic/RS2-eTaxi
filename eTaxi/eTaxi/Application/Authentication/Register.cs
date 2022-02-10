using Domain;
using Model.Others;
using RestSharp;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Text;

namespace Application.Authentication
{
    public partial class Authentication
    {
        public async Task<Response> Register(Register model)
        {
            
            if (await CredentialsAvailable(model))
            {

            

                if (model.IsWeb != true)
                    model.IsWeb = false;
                if (model.UserType == 1)
                {
                    if (model.FirstName == null || model.LastName == null)
                        throw new UserException("Ime i prezime su obavezni.");
                    ApplicationUser user = new ApplicationUser()
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Email = model.Email,
                        SecurityStamp = Guid.NewGuid().ToString(),
                        UserName = model.UserName,
                        UserCreatedTime=DateTime.Now,
                        UserType = UserRoles.Worker
                    };
                    return await CreateUser(user, model.Password, UserRoles.Worker,model.IsWeb);
                }
                if (model.UserType == 2)
                {
                   

                    ApplicationUser user = new ApplicationUser()
                    {
                        Email = model.Email,
                        SecurityStamp = Guid.NewGuid().ToString(),
                        UserName = model.UserName,
                        UserCreatedTime = DateTime.Now,
                        UserType = UserRoles.Owner
                    };
                    return await CreateUser(user, model.Password, UserRoles.Owner,model.IsWeb);
                }
                if (model.UserType == 3)
                {
                   
                    ApplicationUser user = new ApplicationUser()
                    {
                        Email = model.Email,
                        SecurityStamp = Guid.NewGuid().ToString(),
                        UserName = model.UserName,
                        UserCreatedTime = DateTime.Now,
                        UserType=UserRoles.User,
                    };
                    return await CreateUser(user, model.Password, UserRoles.User,model.IsWeb);
                }
            }
            throw new UserException($"{Messages.InternalError}");
        }

    }
}
