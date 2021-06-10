using Application.Interfaces.IServices;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity.Services
{
    public class AuthenticatedUserService : IAuthenticatedUserService
    {
        public AuthenticatedUserService(IHttpContextAccessor httpContextAccessor)
        {
            UserId = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            UserName = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Name);
            Email = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Email);
            Nom = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.GivenName);
            Prenom = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Surname);
            UserRoles = httpContextAccessor.HttpContext?.User?.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value).ToArray();
        }

        public string UserId { get; }
        public string UserName { get; }
        public string Nom { get; }
        public string Prenom { get; }
        public string Email { get; }
        public string[] UserRoles { get; }

    }
}
