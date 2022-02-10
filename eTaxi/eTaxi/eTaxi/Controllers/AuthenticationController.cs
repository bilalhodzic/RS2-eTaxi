using Application.Interfaces;
using Application.INTERFACES;
using AutoMapper;
using Google.Apis.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Model.Others;
using Persistence;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Rezervisi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        readonly eTaxiDbContext _context;

        protected IAuthentication _service;
        private readonly SignInManager<Domain.ApplicationUser> _signInManager;
        private readonly UserManager<Domain.ApplicationUser> _userManager;
        private readonly IJwtGenerator _jwtGenerator;
        private readonly ApplicationSettings _appSettings;
        private readonly IMapper _mapper;


        public AuthenticationController(IAuthentication service, SignInManager<Domain.ApplicationUser> signInManager, UserManager<Domain.ApplicationUser> userManager, IJwtGenerator jwtGenerator, ApplicationSettings appSettings, IMapper mapper, eTaxiDbContext context)
        {
            _signInManager = signInManager;
            _jwtGenerator = jwtGenerator;
            _userManager = userManager;
            _appSettings = appSettings;
            _mapper = mapper;
            _service = service;
            _context = context;
        }


        [HttpGet("verify-email")]
        public async Task<IActionResult> VerifyEmail([FromQuery] VerifyEmail request)
        {
            var uri = await _service.VerifyEmail(request);
            return Redirect(uri);
        }
        [HttpGet("mobile-verify-email")]
        public async Task<bool> MobileVerifyEmail([FromQuery] MobileVerifyEmail request)
        {
            return await _service.MobileVerifyEmail(request);

        }

        /// <summary>
        /// Register for user
        /// </summary>
        /// <param name="model"> UserType 1 je worker, UserType 2 je owner i UserType 3 je obicni korisnik. </param>
        /// <returns> Status </returns>
        [HttpPost]
        [Route("Register")]
        public virtual async Task<Response> Register(Register model)
        {
            return await _service.Register(model);
        }

        [HttpPost]
        [Route("Login")]
        public virtual async Task<SuccessLogin> Login([FromBody] LoginModel model)
        {
            return await _service.Login(model);
        }

        [HttpPost]
        [Route("RegisterAdmin")]
        public virtual async Task<Response> RegisterAdmin([FromBody] RegisterModel model)
        {
            return await _service.RegisterAdmin(model);
        }

        [HttpPost("ForgotPassword")]
        public virtual async Task<Response> ForgotPassword([FromBody] ForgotPassword model)
        {
            return await _service.ForgotPassword(model);
        }

        [HttpPost("ResetPassword")]
        public virtual async Task<Response> ResetPassword(ResetPassword model)
        {
            return await _service.ResetPassword(model);
        }
        [HttpPost("MobileResetPassword")]
        public virtual async Task<Response> MobileResetPassword(MobileResetPassword model)
        {
            return await _service.MobileResetPassword(model);
        }
        [HttpPost("check-pin")]
        public virtual async Task<bool> CheckPin(int id, int pin)
        {
            return await _service.CheckPin(id, pin);
        }

        [HttpGet("external-login")]
        public IActionResult ExternalLogin(string provider)
        {
            var redirectUrl = Url.Action(nameof(HandleExternalLogin));
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);

            return Challenge(properties, provider);
        }

        /// <summary>
        /// Mobilni register i login sa vanjskim providerima
        /// </summary>
        /// <param name="info"> Od front aplikacije koja iskomunicira sa eksternim providerom backend ocekuje ime, prezime, email, eksterni user id i token, od developera se ocekuje da posalje provider name ("Google" , "Facebook", ...) u zavisnosti s kojeg providera je aplikacija dobila podatke    </param>
        /// <returns> Status </returns>
        [HttpPost("mobile-handle-external-login")]
        public async Task<SuccessLogin> HandleMobileExternalLogin([FromBody] MobileExternalLogin info)
        {

            try
            {
                if(info.Provider.ToLower()!=Providers.Google && info.Provider.ToLower() != Providers.Facebook)
                    throw new UserException("Invalid provider");

                if (info.Provider.ToLower() == Providers.Google)
                {
                    await GoogleJsonWebSignature.ValidateAsync(info.Token);
                }
                if (info.Provider.ToLower() == Providers.Facebook)
                {
                    var uri = "https://graph.facebook.com/me?access_token=" + info.Token;
                    var client = new HttpClient();
                    var x = await client.GetAsync(uri);
                    if (x.StatusCode != System.Net.HttpStatusCode.OK)
                    {
                        throw new UserException("Invalid token");
                    }
                }
                var email = info.Email;
                var name = info.FullName;
                var firstName = name.Split(" ")[0];
                var lastName = name.Split(" ")[1];
                var result = await _signInManager.ExternalLoginSignInAsync(info.Provider, info.Id, isPersistent: false);
                if (result.Succeeded && await _userManager.FindByEmailAsync(email)!=null)
                {
                    var user = await _userManager.FindByEmailAsync(email);
                    var loginuser = _mapper.Map<LoginModel>(user);
                    var token = await _service.Login(loginuser,true);
                    return new SuccessLogin { Token = token.Token, RefreshToken=token.RefreshToken };
                }
                else
                {
                    if (email != null)
                    {
                        var user = await _userManager.FindByEmailAsync(email);

                        if (user == null)
                        {
                            user = new Domain.ApplicationUser
                            {
                                UserName = email,
                                Email = email,
                                FirstName = firstName,
                                LastName = lastName,
                                EmailConfirmed = true,
                                UserCreatedTime = DateTime.Now,
                                UserType = UserRoles.User,
                                LockoutEnabled = false,
                                IsActive = true
                            };
                            await _userManager.CreateAsync(user);
                            await _userManager.AddToRoleAsync(user, UserRoles.User);
                        }
                        await _userManager.UpdateAsync(user);
                        var LoginInfo = new UserLoginInfo(info.Provider, info.Id, info.Provider);
                        await _userManager.AddLoginAsync(user, LoginInfo);
                        await _signInManager.SignInAsync(user, isPersistent: false);

                        var loginuser = _mapper.Map<LoginModel>(user);
                        var token = await _service.Login(loginuser,true);
                        return new SuccessLogin { Token = token.Token,RefreshToken=token.RefreshToken };
                    }
                    throw new UserException("Provider did not provide all information about you.");
                }
            }
            catch (Exception)
            {
                throw new UserException("Provider did not provide all information about you.");
            }
        }

        [HttpGet("handle-external-login")]
        public async Task<IActionResult> HandleExternalLogin()
        {
            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                var fullUrl = _appSettings.AppUrl + "/#/account/external-provider-fail?provider=" + info.LoginProvider;
                var uri = new Uri(fullUrl);
                return Redirect(uri.AbsoluteUri);
            }

            try
            {
                var email = info.Principal.FindFirstValue(ClaimTypes.Email);
                var name = info.Principal.FindFirstValue(ClaimTypes.Name);
                var firstName = name.Split(" ")[0];
                var lastName = name.Split(" ")[1];
                var nameIdentifier = info.Principal.FindFirstValue(ClaimTypes.NameIdentifier);

                var picture = "https://graph.facebook.com/" + nameIdentifier + "/picture?type=large";

                if (info.LoginProvider == "Google")
                {
                    picture = info.Principal.FindFirstValue("picture");
                }

                var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false);
                if (result.Succeeded)
                {
                    var user = await _userManager.FindByEmailAsync(email);
                    var loginuser = _mapper.Map<LoginModel>(user);
                    var token = _jwtGenerator.GenerateToken(loginuser, user.Id, user.VerifiedAccount);

                    var fullUrl = _appSettings.AppUrl + "/login?token=" + token;
                    var uri = new Uri(fullUrl);
                    return Redirect(uri.AbsoluteUri);
                }
                else
                {
                    string fullUrl;
                    Uri uri;
                    if (email != null)
                    {
                        var user = await _userManager.FindByEmailAsync(email);

                        if (user == null)
                        {

                            user = new Domain.ApplicationUser
                            {
                                UserName = info.Principal.FindFirstValue(ClaimTypes.Email),
                                Email = info.Principal.FindFirstValue(ClaimTypes.Email),
                                FirstName = firstName,
                                LastName = lastName,
                                EmailConfirmed = true,
                                UserCreatedTime = DateTime.Now,
                                UserType = UserRoles.Owner,
                                LockoutEnabled = false
                                // info.Principal.FindFirstValue(ClaimTypes.Gender);
                            };
                            await _userManager.CreateAsync(user);
                            await _userManager.AddToRoleAsync(user, UserRoles.Owner);
                        }
                        await _userManager.UpdateAsync(user);
                        await _userManager.AddLoginAsync(user, info);
                        await _signInManager.SignInAsync(user, isPersistent: false);

                        var loginuser = _mapper.Map<LoginModel>(user);
                        var token = _jwtGenerator.GenerateToken(loginuser, user.Id, user.VerifiedAccount);
                        fullUrl = _appSettings.AppUrl + "/login?token=" + token;
                        uri = new Uri(fullUrl);


                        return Redirect(uri.AbsoluteUri);

                    }
                    fullUrl = _appSettings.AppUrl + "/#/account/externer-provider-fail?provider=" + info.LoginProvider;
                    uri = new Uri(fullUrl);
                    return Redirect(uri.AbsoluteUri);
                }
            }
            catch (Exception)
            {
                throw new UserException("Provider did not provide all information about you.");
            }
        }
        [Authorize]
        [HttpPost("change-email/{id}")]
        public async Task<bool> ChangeEmail(int id, ChangeEmail request)
        {
            return await _service.ChangeEmail(id, request);
        }

        [HttpGet("confirm-change-email")]
        public async Task<RedirectResult> ConfirmChangeEmail([FromQuery] ConfirmChangeEmail request)
        {
            var url = await _service.ConfirmChangeEmail(request);

            return Redirect(url);
        }

        [Authorize]
        [HttpPost("change-password-from-settings/{id}")]
        public async Task<bool> ChangePasswordFromSettings(int id, ChangePassword request)
        {
            return await _service.ChangePasswordFromSettings(id, request);
        }

        [Authorize]
        [HttpPost("change-email-mobile/{id}")]
        public async Task<bool> ChangeEmailMobile(int id, ChangeEmail request)
        {
            return await _service.ChangeEmailMobile(id, request);
        }

        [Authorize]
        [HttpPost("confirm-change-email-mobile")]
        public async Task<Response> ConfirmChangeEmailMobile(ConfirmChangeEmail request)
        {
            return await _service.ConfirmChangeEmailMobile(request);
        }

        [HttpPost("check-email")]
        public async Task<bool> MobileCheckMail(string Email)
        {
            return await _service.MobileCheckMail(Email);
        }

        [HttpPost("deactivate-account")]
        public async Task<bool> DeactivateAccount([FromQuery] int id)
        {
            return await _service.DeactivateAccount(id);
        }
        [HttpPost]
        [Route("refresh")]
        public SuccessLogin Refresh(TokenApiModel tokenApiModel)
        {
           return _service.Refresh(tokenApiModel);
        }
        [HttpPost, Authorize]
        [Route("revoke")]
        public IActionResult Revoke()
        {
            var username = User.Identity.Name;
            var user = _context.ApplicationUsers.SingleOrDefault(u => u.UserName == username);
            if (user == null) return BadRequest();
            user.RefreshToken = null;
            _context.SaveChanges();
            return NoContent();
        }
    }
}
