using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TreatLines.BLL.Interfaces;

namespace TreatLines.BLL.Services
{
    public sealed class MailService : IMailService
    {
        private EmailOptions options;

        public MailService(IConfiguration configuration)
        {
            options = new EmailOptions();
            options.Email = "admin@gmail.com";
            //configuration.Bind("Email", options);
        }

        public async Task SendAsync(string receiver, string subject, string bodyHtml)
        {
            if (!options.Enabled)
            {
                return;
            }

            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress(string.Empty, options.Email));
            emailMessage.To.Add(new MailboxAddress(string.Empty, receiver));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = bodyHtml
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(options.Server, options.Port, options.UseSSL);
                await client.AuthenticateAsync(options.Email, options.Password);

                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);
            }
        }

        private class EmailOptions
        {
            public bool Enabled { get; set; }

            public string Name { get; set; }

            public string Email { get; set; }

            public string Password { get; set; }

            public string Server { get; set; }

            public int Port { get; set; }

            public bool UseSSL { get; set; }
        }
    }
}
