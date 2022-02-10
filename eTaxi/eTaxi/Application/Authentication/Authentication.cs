using Application.Interfaces;
using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Model.Others;
using Persistence;

namespace Application.Authentication
{
    public partial class Authentication : IAuthentication
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        private readonly IMapper _mapper;
        private readonly IJwtGenerator _jwtGenerator;
        public readonly IEmail _EmailService;
        private readonly ApplicationSettings _appSettings;
        private readonly eTaxiDbContext _context;
        private readonly IConfiguration _configuration;

        public Authentication(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole<int>> roleManager, IMapper mapper, IJwtGenerator jwtGenerator, IEmail EmailService, ApplicationSettings appSettings, SignInManager<ApplicationUser> signInManager, eTaxiDbContext context, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
            _jwtGenerator = jwtGenerator;
            _EmailService = EmailService;
            _appSettings = appSettings;
            _context = context;
            _configuration = configuration;
        }
    }
}

