using Domain.Models;
using Domain.Services.Auth;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using System.Net;
using System.Net.Mail;






    //private readonly EmailSettings _settings;


    //public EmailService(IOptions<EmailSettings> settings)
    //{
    //    _settings = settings.Value;
    //}

    //public async Task SendEmailAsync(string to, string subject, string body)
    //{
    //    var email = new MimeMessage();
    //    email.From.Add(new MailboxAddress("SkillTrackPro", _settings.FromEmail));
    //    email.To.Add(new MailboxAddress("", to));
    //    email.Subject = subject;

    //    email.Body = new TextPart("plain") { Text = body };

    //    using var smtp = new SmtpClient();
    //    await smtp.ConnectAsync(_settings.SmtpServer, _settings.Port, false);
    //    await smtp.AuthenticateAsync(_settings.Username, _settings.Password);
    //    await smtp.SendAsync(email);
    //    await smtp.DisconnectAsync(true);
    //}

    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;

        public EmailService(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string message)
        {
            using (var smtp = new System.Net.Mail.SmtpClient())
            {
                smtp.Host = _emailSettings.Host;
                smtp.Port = _emailSettings.Port;
                smtp.EnableSsl = true;

                smtp.Credentials = new NetworkCredential(_emailSettings.Email, _emailSettings.Password);

                var mail = new MailMessage()
                {
                    From = new MailAddress(_emailSettings.Email),
                    Subject = subject,
                    Body = message,
                    IsBodyHtml = true
                };

                mail.To.Add(toEmail);

                await smtp.SendMailAsync(mail);
            }
        }
    }

