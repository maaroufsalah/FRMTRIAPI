using Application.Interfaces.IServices;
using Application.Models.Services.Account;
using Application.Settings;
using Application.Wrappers;
using Infrastructure.Persistence.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace FRMTRI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseApiController
    {

        #region Header
        private readonly ILogger<AccountController> _logger;
        private readonly IAccountService _accountService;
        private readonly AuthenticationSettings _authenticationSettings;

        public AccountController(
            ILogger<AccountController> logger,
            IAccountService accountService,
            IOptions<AuthenticationSettings> authenticationSettings,

            MainContext mainContext
            )
        {
            _logger = logger;
            _accountService = accountService;
            _authenticationSettings = authenticationSettings.Value;
        }
        #endregion

        #region Actions

        [HttpPost("register")]
        public async Task<ActionResult<RegisterRequest>> Register(RegisterRequest register)
        {
            try
            {
                await _accountService.RegisterAsync(register);

                return register;
            }
            catch (Exception ex)
            {
                return BadRequest("Message : " + ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<Response<AuthenticatedUser>>> Login(AuthenticationRequest authenticationRequest)
        {
            try
            {
                var response = await _accountService.AuthenticateAsync(authenticationRequest);
                var uri = _authenticationSettings.LoginRedirectUri;
                if (!response.Succeeded)
                    return Unauthorized(response.Message);
                else
                    return response;
            }
            catch (Exception ex)
            {
                //_logger.LogError(exception: ex, controller: this);
                //return this.GetJsonMessage(response.Message, MessageTypes.Error.ToString(), false);
                return BadRequest(ex.Message);
            }
        }

        #endregion

        #region Functions

        #endregion
    }
}
