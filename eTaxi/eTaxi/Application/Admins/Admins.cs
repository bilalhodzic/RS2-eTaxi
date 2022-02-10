using Application.Interfaces;
using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Identity;
using Model.Dto;
using Model.Others;
using Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Admins
{
    public partial class Admins:IAdmin
    {
        private readonly UserManager<ApplicationUser> _userManager;
        protected readonly eTaxiDbContext _context;
        protected readonly IMapper _mapper;

        public Admins(eTaxiDbContext context, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<bool> ChangeAdminPass(AdminResetPassword Model)
        {

            var user = await _userManager.FindByIdAsync(Model.ID.ToString());
            if (user == null || user.UserType!=UserRoles.Admin)
            {
                throw new UserException("Benutzer wurde nicht gefunden oder Benutzertyp ist nicht admin!");
            }
            var hashPassword = _userManager.PasswordHasher.HashPassword(user, Model.Password);
            user.PasswordHash = hashPassword;
            var result= await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return true;
            }
            else
                throw new UserException("Error");


        }
    }
    
}
