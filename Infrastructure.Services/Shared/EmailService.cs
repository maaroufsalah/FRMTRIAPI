using Application.Interfaces.IServices;
using Application.Models.Services.Email;
using Infrastructure.Services.Settings;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace Infrastructure.Services.Shared
{
    public class EmailService : IEmailService
    {
        public SmtpSetting _mailSettings { get; }
        //public ILogger<EmailService> _logger { get; }

        public EmailService(IOptions<SmtpSetting> mailSettings)
        {
            _mailSettings = mailSettings.Value;
            //_logger = logger;
        }

        //public async Task SendAsync(EmailRequest request)
        //{
        //    try
        //    {
        //        // create message
        //        var email = new MimeMessage();
        //        email.Sender = MailboxAddress.Parse(request.From ?? _mailSettings.EmailFrom);
        //        email.To.Add(MailboxAddress.Parse(request.To));
        //        email.Subject = request.Subject;
        //        var builder = new BodyBuilder();
        //        builder.HtmlBody = request.Body;
        //        email.Body = builder.ToMessageBody();
        //        using var smtp = new MailKit.Net.Smtp.SmtpClient();
        //        smtp.Connect(_mailSettings.SmtpHost, _mailSettings.SmtpPort, SecureSocketOptions.StartTls);
        //        smtp.Authenticate(_mailSettings.SmtpUser, _mailSettings.SmtpPass);
        //        await smtp.SendAsync(email);
        //        smtp.Disconnect(true);

        //    }
        //    catch (System.Exception ex)
        //    {
        //        //_logger.LogError(ex.Message, ex);
        //        throw new GlobalException(ex.Message);
        //    }
        //}
    }
}