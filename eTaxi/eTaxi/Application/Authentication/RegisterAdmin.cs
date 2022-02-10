using Domain;
using Microsoft.AspNetCore.Identity;
using Model.Others;
using System;
using System.Threading.Tasks;

namespace Application.Authentication
{
    public partial class Authentication
    {
        public  async Task<Response> RegisterAdmin(RegisterModel model)
        {
            var Register = _mapper.Map<Register>(model);
            if (await CredentialsAvailable(Register))
            {

                ApplicationUser user = new ApplicationUser()
                {
                    Email = model.Email,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = model.UserName,
                    UserType = UserRoles.Admin,
                    VerifiedAccount = true,
                };
                await CreateUser(user, model.Password, UserRoles.Admin,false);

                if (!await _roleManager.RoleExistsAsync(UserRoles.User))
                    await _roleManager.CreateAsync(new IdentityRole<int>(UserRoles.User));

                if (!await _roleManager.RoleExistsAsync(UserRoles.Worker))
                    await _roleManager.CreateAsync(new IdentityRole<int>(UserRoles.Worker));


                if (!await _roleManager.RoleExistsAsync(UserRoles.Owner))
                    await _roleManager.CreateAsync(new IdentityRole<int>(UserRoles.Owner));

                if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
                    await _roleManager.CreateAsync(new IdentityRole<int>(UserRoles.Admin));

                if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
                {
                    await _userManager.AddToRoleAsync(user, UserRoles.Admin);
                }

                return new Response { Status = Messages.Success, Message = Messages.UserCreated };
            }
            return new Response { Status = Messages.Error, Message = Messages.UserExist };

        }
    }
}
