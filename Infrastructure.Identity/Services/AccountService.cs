using Application.Constants;
using Application.Enums;
using Application.Interfaces.IHelper;
using Application.Interfaces.IServices;
using Application.Models.Services.Account;
using Application.Wrappers;
using Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Application.Constants.ApplicationMessage;

namespace Infrastructure.Identity.Services
{
    public class AccountService : IAccountService
    {

        #region Header
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ITokenService _tokenService;

        public AccountService(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<ApplicationUser> signInManager,
            ITokenService tokenService
            )
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }
        #endregion


        #region Services
        public async Task<Response<AuthenticatedUser>> AuthenticateAsync(AuthenticationRequest request)
        {
            // case existed user
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null)
                return new Response<AuthenticatedUser>(string.Format(ExceptionMessage.Authentication.AUTH_NOT_FOUND, request.UserName));

            var checkPassword = await _userManager.CheckPasswordAsync(user, request.Password);

            if (!checkPassword)
                return new Response<AuthenticatedUser>(string.Format(ExceptionMessage.Authentication.AUTH_ERR_CREDENTIALS, request.UserName));

            await _signInManager.SignInAsync(user, new AuthenticationProperties()
            {
                IsPersistent = request.RememberMe
            });

            // Create and return user
            AuthenticatedUser response = new AuthenticatedUser();
            response.Id = user.Id;
            response.Nom = user.Nom;
            response.Prenom = user.Prenom;
            response.UserName = user.UserName;
            response.Email = user.Email;
            var rolesList = await _userManager.GetRolesAsync(user).ConfigureAwait(false);
            response.Roles = rolesList.ToList();
            response.IsVerified = user.EmailConfirmed;
            response.JWToken = _tokenService.CreateToken(request);
            return new Response<AuthenticatedUser>(response, string.Format(AuthenticationMessage.AUTHENTICATION_SUCCESS, user.UserName));
        }

        public async Task<Response<string>> RegisterAsync(RegisterRequest request)
        {
            // Case existed user
            var userWithSameUserName = await _userManager.FindByNameAsync(request.Email);
            if (userWithSameUserName != null)
                return new Response<string>(string.Format(AuthenticationMessage.REG_USER_TAKEN, request.UserName));
            var user = new ApplicationUser
            {
                Email = request.Email,
                Nom = request.Nom,
                Prenom = request.Prenom,
                UserName = request.UserName
            };

            // Case existed Email
            var userWithSameEmail = await _userManager.FindByEmailAsync(request.Email);
            if (userWithSameEmail != null)
                return new Response<string>(string.Format(AuthenticationMessage.REG_EMAIL_TAKEN, user.Email));

            // Create User
            var result = await _userManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
            {
                //await _userManager.AddToRoleAsync(user, Roles.Athlete.ToString());
                await _userManager.AddToRoleAsync(user, request.RoleId);
                return new Response<string>(user.Id, message: string.Format(AuthenticationMessage.REGISTRE_SUCCESS, request.UserName));
            }
            else
                return new Response<string>(string.Format(AuthenticationMessage.REG_ERROR, request.UserName));

        }

        public async void LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }
        #endregion



    }
}
