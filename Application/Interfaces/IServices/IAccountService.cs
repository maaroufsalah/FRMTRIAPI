using Application.Models.Services.Account;
using Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IServices
{
    public interface IAccountService
    {
        Task<Response<AuthenticatedUser>> AuthenticateAsync(AuthenticationRequest request);
        Task<Response<string>> RegisterAsync(RegisterRequest request);
        void LogoutAsync();
    }
}
