using Application.Interfaces.IHelper;
using Application.Interfaces.IServices;
using Application.Settings;
using Infrastructure.Identity.Contexts;
using Infrastructure.Identity.Helpers;
using Infrastructure.Identity.Models;
using Infrastructure.Identity.Services;
using Infrastructure.Identity.Settings;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity
{
    public static class ServiceExtensions
    {
        public static void AddIdentityInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<IdentityContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("IdentityConnection"),
                b => b.MigrationsAssembly(typeof(IdentityContext).Assembly.FullName)));

            services.AddIdentity<ApplicationUser, IdentityRole>().
                AddRoleManager<RoleManager<IdentityRole>>().
                AddEntityFrameworkStores<IdentityContext>().
                AddClaimsPrincipalFactory<UserClaimsFactory>();

            //services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(config =>
            //{
            //    config.Cookie.Name = CookieAuthenticationDefaults.AuthenticationScheme;
            //    config.LoginPath = configuration.GetValue<string>("AuthenticationSettings:LoginUri");
            //    config.AccessDeniedPath = configuration.GetValue<string>("AuthenticationSettings:AccessDeniedUri");
            //});


            // Add Token Configuration from AuthenticationHelper Extension
            services.AddTokenServices(
                configuration.GetValue<string>("JWTSettings:Issuer"), 
                configuration.GetValue<string>("JWTSettings:Audience"), 
                configuration.GetValue<string>("JWTSettings:Key"));


            #region Services

            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IAuthenticatedUserService, AuthenticatedUserService>();
            services.AddScoped<ITokenService, TokenService>();
            services.Configure<AuthenticationSettings>(configuration.GetSection("AuthenticationSettings"));
            services.Configure<JWTSettings>(configuration.GetSection("JWTSettings"));
            
            #endregion
        }

    }
}
