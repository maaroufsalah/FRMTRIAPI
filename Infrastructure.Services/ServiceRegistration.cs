using Application.Interfaces.IServices;
using Infrastructure.Services.Service;
using Infrastructure.Services.Settings;
using Infrastructure.Services.Shared;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public static class ServiceRegistration
    {
        public static void AddServiceInfrastructure(this IServiceCollection services, IConfiguration _config)
        {
            services.Configure<SmtpSetting>(_config.GetSection("MailSettings"));

            services.AddTransient<IDateTimeService, DateTimeService>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<INotificationStorage, NotificationStorage>();
        }
    }
}
